using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveRecipie : MonoBehaviour
{
    public Recipie activeRecipie;
    public GameObject readyButton;
    public GameObject casserole;

    // Start is called before the first frame update
    void Start () {
  		Button btn = readyButton.GetComponent<Button>();
  		btn.onClick.AddListener(CheckRecipie);
  	}

  	void CheckRecipie(){
  		Debug.Log (activeRecipie.Title+"C'est prêt!");

      Debug.Log ("score : " + ComputeScore().ToString());
  	}

    float ComputeScore(){
      Transform slots = casserole.transform.GetChild(0);
      int childrenNb = slots.childCount;
      int ingredientNb = activeRecipie.lstIngredients.Count;
      float score = 0.0f;
       for (int i = 0; i < ingredientNb; ++i) {
         int match = 0;
         GameObject objRecipie = activeRecipie.lstIngredients[i].ingredient;
         if (i < childrenNb) {
           GameObject objSlot = slots.GetChild(i).gameObject;
           if (objSlot == objRecipie) {
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
