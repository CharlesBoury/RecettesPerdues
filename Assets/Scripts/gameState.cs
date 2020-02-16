using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public enum State{
  pregame, game, endgame
};

public class gameState : MonoBehaviour
{
    public State state;
    public GameObject ingredientsContainer;
    public GameObject casserole;
    private Transform slots;
    public Recipie activeRecipie;
    public GameObject readyButton;
    public GameObject miamometer;

    public List<GameObject> ingredients;
    // Start is called before the first frame update
    void Start()
    {
      state = State.pregame;
      Button btn = readyButton.GetComponent<Button>();
  		btn.onClick.AddListener(Finish);
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
      if (state == State.pregame || state == State.endgame) {
        miamometer.GetComponent<Canvas>().enabled=false;
        foreach(GameObject objet in ingredients) {
          GameObject instance = Instantiate(objet);
          instance.transform.parent = ingredientsContainer.transform;
          ClampToAir cl = instance.GetComponent<ClampToAir>();
          if (cl != null) {
            cl.casserole = casserole;
          }
          Cookable ck = instance.GetComponent<Cookable>();
          if (ck != null) {
            ck.casserole = casserole;
          }
          instance.name = objet.name;
        }
        state = State.game;

      }
    }

    void Finish(){
      float score = ComputeScore();
  		Debug.Log (activeRecipie.Title+"C'est prêt!");
      Debug.Log ("score : " + score.ToString());
      state = State.endgame;
      DestroyGame();
      miamometer.GetComponent<Canvas>().enabled=true;
      miamometer.transform.GetChild(1).GetComponent<Slider>().value = score;
      Button btn = miamometer.transform.GetChild(2).GetComponent<Button>();
  		btn.onClick.AddListener(InitiateGame);
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
       float score = scoreOrder * 0.4f + scoreMatch * 0.5f + scoreBonus;
       if (score > 1.0f) {
         score = 0.0f;
       }
       return score;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
