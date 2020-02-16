using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookable : MonoBehaviour
{
    public GameObject 	casserole;
    private Transform slots;
    public bool       	inCasserole = false;
    public GameObject   Draggable;
    public Bonus bonus;
    public GameObject   gameState;

    void Start()
    {
      bonus = Bonus.aucun;
      foreach (Transform child in casserole.transform) {
        if (child.name == "Slots") {
          slots = child;
        }
      }
    }

    private void OnMouseUp() {
    	if (Input.GetMouseButtonUp(0)) {

            // Check if in casserole
            if (transform.GetChild(0).GetComponent<Collider2D>().IsTouching(casserole.GetComponent<Collider2D>())) {
                this.gameObject.transform.parent = slots;
                this.GetComponent<Collider2D>().enabled = false;
                inCasserole = true;
                casserole.GetComponent<Casserole>().PlayBloup();
                gameState.GetComponent<gameState>().UpdateAvancee();
            }

        }
    }

    void	Update()
    {
    }


 }
