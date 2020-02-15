using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameState : MonoBehaviour
{
    public int state;
    public GameObject ingredientsContainer;
    public GameObject casserole;
    private Transform slots;
    public Recipie activeRecipie;
    public GameObject readyButton;

    public List<GameObject> ingredients;
    // Start is called before the first frame update
    void Start()
    {
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
      state = 0;
      foreach(GameObject objet in ingredients) {
        GameObject instance = Instantiate(objet);
        instance.transform.parent = ingredientsContainer.transform;
        instance.GetComponent<Draggable>().casserole = casserole;
        instance.name = objet.name;
      }
    }

    void Finish(){
  		Debug.Log (activeRecipie.Title+"C'est prêt!");
      Debug.Log ("score : " + ComputeScore().ToString());
      state = 1;
      DestroyGame();
      InitiateGame();
  	}

    float ComputeScore(){
      int childrenNb = slots.childCount;
      int ingredientNb = activeRecipie.lstIngredients.Count;
      float score = 0.0f;
       for (int i = 0; i < ingredientNb; ++i) {
         int match = 0;
         string objRecipie = activeRecipie.lstIngredients[i].ingredient;
         if (i < childrenNb) {
           GameObject objSlot = slots.GetChild(i).gameObject;
           if (objSlot.name == objRecipie) {
             match = 1;
           }
           score = score + match;
         }
       }
       return score;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
