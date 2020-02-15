using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookable : MonoBehaviour
{
    public GameObject 	casserole;
    private Transform slots;
    public bool       	inCasserole = false;

    void Start()
    {
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

            }

        }
    }

    void	Update()
    {
    }


 }
