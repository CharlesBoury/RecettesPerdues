using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameState : MonoBehaviour
{
    public int state;
    public List<GameObject> ingredients;
    public GameObject ingredientsContainer;
    public GameObject casserole;
    // Start is called before the first frame update
    void Start()
    {
      InitiateGame();
    }

    void InitiateGame()
    {
      state = 0;
      foreach(GameObject objet in ingredients) {
        GameObject instance = Instantiate(objet);
        instance.transform.parent = ingredientsContainer.transform;
        instance.GetComponent<Draggable>().casserole = casserole;
      }

    }
    // Update is called once per frame
    void Update()
    {

    }
}
