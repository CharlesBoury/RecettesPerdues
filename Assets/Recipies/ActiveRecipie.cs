using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveRecipie : MonoBehaviour
{
    public Recipie activeRecipie;
    public GameObject readyButton;

    // Start is called before the first frame update
    void Start () {
  		Button btn = readyButton.GetComponent<Button>();
  		btn.onClick.AddListener(CheckRecipie);
  	}

  	void CheckRecipie(){
  		Debug.Log ("You have clicked the button!");
      Debug.Log (activeRecipie.Title);
  	}

    // Update is called once per frame
    void Update()
    {

    }
}
