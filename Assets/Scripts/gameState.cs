using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public enum State{
  pregame, game, endgame, menurecettes
};

public class gameState : MonoBehaviour
{
    public State state;
    public GameObject ingredientsContainer;
    public GameObject casserole;
    private Transform slots;
    public List<Recipie> lstRecipies;
    public Recipie activeRecipie;
    public GameObject panel;
    public GameObject miamometer;
    public lerpSlider miamometerSlider;
    public Condiments condiments;
    public Vector3    avanceeOriginPos;
    private int       avanceeCount;

    public List<GameObject> ingredients;

    private GameObject readyButton;
    private GameObject mijoteButton;
    private GameObject avancee;
    private bool tropSale;
    private bool ilmanqueqqchose;

    // Start is called before the first frame update
    void Start()
    {
      state = State.pregame;
      avancee = panel.transform.GetChild(0).gameObject;
      readyButton = panel.transform.GetChild(2).gameObject;
      mijoteButton = panel.transform.GetChild(3).gameObject;
      avanceeOriginPos = avancee.transform.localPosition;

      activeRecipie = lstRecipies[Random.Range(0, lstRecipies.Count)];

      panel.GetComponent<Image>().sprite = activeRecipie.sprite;

      Button btn = readyButton.GetComponent<Button>();
  		btn.onClick.AddListener(Finish);

      Button btn2 = mijoteButton.GetComponent<Button>();
      btn2.onClick.AddListener(Mijote);

      foreach (Transform child in casserole.transform) {
        if (child.name == "Slots") {
          slots = child;
        }
      }

      InitiateGame();
    }

    void DestroyGame()
    {
      foreach (Transform child in ingredientsContainer.transform) {
        GameObject.Destroy(child.gameObject);
      }
      foreach (Transform child in slots) {
        GameObject.Destroy(child.gameObject);
      }
    }

    void InitiateGame()
    {
      condiments.Init();
      tropSale = false;
      ilmanqueqqchose = false;
      activeRecipie = lstRecipies[Random.Range(0, lstRecipies.Count)];
      panel.GetComponent<Image>().sprite = activeRecipie.sprite;

      if (state == State.pregame || state == State.endgame) {
        miamometerSlider.value = 0;
        miamometer.SetActive(false);
        foreach(GameObject objet in ingredients) {
          GameObject instance = Instantiate(objet);
          instance.transform.parent = ingredientsContainer.transform;
          Cookable ck = instance.GetComponent<Cookable>();
          if (ck != null) {
            ck.casserole = casserole;
            ck.gameState = gameObject;
          }
          instance.name = objet.name;
        }
        state = State.game;
        avancee.transform.localPosition = avanceeOriginPos;
        avanceeCount = 0;

      }
    }

    void Finish(){
      float score = ComputeScore();
  		Debug.Log (activeRecipie.Title+"C'est prêt!");
      state = State.endgame;
      DestroyGame();
      miamometer.SetActive(true);
      miamometerSlider.value = score;
      miamometer.GetComponent<PlaySong>().PlayBloup();
      Button btn = miamometer.transform.GetChild(2).GetComponent<Button>();
  		btn.onClick.AddListener(InitiateGame);

      Button btn2 = miamometer.transform.GetChild(3).GetComponent<Button>();
      btn2.onClick.AddListener(MenuRecettes);
  	}

    float ComputeScore(){
      int childrenNb = slots.childCount;
      int ingredientNb = activeRecipie.lstIngredients.Count;
      List<string> ingredientNames = new List<string>();
      List<string> recipieNames = new List<string>();
      float scoreBonus = 0.05f; // Gratuit !
      float scoreOrder = 0.0f;
      float scoreMatch = 0.0f;
      for (int i = 0; i < ingredientNb; ++i) {
         int match = 0;
         string objRecipie = activeRecipie.lstIngredients[i].ingredient;
         Debug.Log("ingredients" + i.ToString() + " " + objRecipie);
         if (i < childrenNb) {
           GameObject objSlot = slots.GetChild(i).gameObject;
           // Check exact matching
           if (objSlot.name == objRecipie) {
             match = 1;
           }
           // Bonus action at the right time
           if (activeRecipie.lstIngredients[i].bonus != Bonus.aucun && objSlot.GetComponent<Cookable>().bonus == activeRecipie.lstIngredients[i].bonus) {
              scoreBonus += 0.05f;
           }
           // Build lists
           ingredientNames.Add(objSlot.name);
           recipieNames.Add(objRecipie);
           scoreOrder = scoreOrder + match;
         }
       }
       int nbMatch = (ingredientNames.Intersect(recipieNames)).Count();
       scoreMatch =  nbMatch * 1.0f / ingredientNb;
       scoreOrder = scoreOrder / ingredientNb;
       float scoreCondiments = CondimentScore(activeRecipie.condiments);
       float score = scoreOrder * 0.4f + scoreMatch * 0.4f + scoreCondiments * 0.4f + scoreBonus;
       if (score > 1.0f) {
         score = 1.0f;
       }
       if (score < 0.1f) {
         score = 0.1f;
       }
       Debug.Log ("score order: " + scoreOrder.ToString() + " match: "+ scoreMatch.ToString() + " condiments: "+ scoreCondiments.ToString() + " bonus: "+ scoreBonus.ToString() + " Total: " + score.ToString());
       return score;
    }

    float CondimentScore(Condiments condRef) {
      Debug.Log("sel: " + condiments.sel.ToString() + " ref sel: " + condRef.sel.ToString());
      if (condiments.sel > 1.0f) condiments.sel = 1.0f;
      if (condiments.poivre > 1.0f) condiments.poivre = 1.0f;
      if (condiments.creme > 1.0f) condiments.creme = 1.0f;
      if (condiments.miel > 1.0f) condiments.miel = 1.0f;
      if (condiments.soja > 1.0f) condiments.soja = 1.0f;
      if (condiments.coco > 1.0f) condiments.coco = 1.0f;
      if (condiments.sel > condRef.sel + 0.25) tropSale = true;
      float selDiff = 2.0f * (condRef.sel - condiments.sel) * (condRef.sel - condiments.sel);
      float poivreDiff = Mathf.Abs(condRef.poivre - condiments.poivre);
      float mielDiff = 0.0f; //Mathf.Abs(condRef.miel - condiments.miel);
      float sojaDiff = 0.0f; //Mathf.Abs(condRef.soja - condiments.soja);
      float cocoDiff = 0.0f; //Mathf.Abs(condRef.coco - condiments.coco);
      float huileDiff = 0.0f; //Mathf.Abs(condRef.huile - condiments.huile);
      float diff = 1.0f - (selDiff + poivreDiff + mielDiff + sojaDiff + cocoDiff + huileDiff);
      if (diff < -0.1f) {
        diff = -0.1f;
      }
      return diff;
    }

    public GameObject getLatestLegume() {
      int nbChild = slots.childCount;
      if (nbChild == 0) {
        return null;
      }
      return slots.GetChild(nbChild-1).gameObject;
    }

    public void MenuRecettes() {
      state = State.menurecettes;
    }

    public BoxCollider2D getCollider() {
      return casserole.GetComponent<BoxCollider2D>();
    }

    public void ImpactParticle(string name, int num) {
      //Debug.Log("name:"+name+num.ToString());
      switch(name) {
        case "Sel": condiments.sel += num / 400.0f; break;
        case "Poivre": condiments.poivre += num / 400.0f; break;
        case "Miel": condiments.miel += num / 20.0f; break;
        case "Crème": condiments.creme += num / 20.0f; break;
        case "Soja": condiments.soja += num / 30.0f; condiments.sel += num / 30.0f; break;
        case "Huile": condiments.huile += num / 10.0f; break;
        case "Laitdecoco": condiments.coco += num / 10.0f; break;
      }
    }

    public void Touille() {
      GameObject latestChild = getLatestLegume();
      if (latestChild != null) {
        if (latestChild.GetComponent<Cookable>().bonus == Bonus.aucun) {
          latestChild.GetComponent<Cookable>().bonus = Bonus.touille;
        }
      }
    }

    public void Mijote() {
      //Debug.Log("sel: "+condiments.sel.ToString()+" poivre: "+condiments.poivre.ToString()+" miel: "+condiments.miel.ToString()+" creme: "+condiments.creme.ToString()+" soja: "+condiments.soja.ToString()+" coco: "+condiments.coco.ToString());
      GameObject latestChild = getLatestLegume();
      if (latestChild != null) {
        if (power_picker.fire_power > 0.7f) {
          latestChild.GetComponent<chaud>().PlaySound();
        }
        if (latestChild.GetComponent<Cookable>().bonus != Bonus.mijotefort) {
          if (power_picker.fire_power > 0.7f) {
            latestChild.GetComponent<Cookable>().bonus = Bonus.mijotefort;
          } else {
            latestChild.GetComponent<Cookable>().bonus = Bonus.mijotefaible;
          }
        }
      }
    }

    public void  UpdateAvancee()
    {
      //Debug.Log(panel.recetteImage.GetComponent<RectTransform>().Height.ToString());
      if (avanceeCount < activeRecipie.lstIngredients.Count)
      {
        avancee.transform.localPosition = new Vector3(avancee.transform.localPosition.x + 2, avancee.transform.localPosition.y - 93, 0);
        avanceeCount++;
      }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
