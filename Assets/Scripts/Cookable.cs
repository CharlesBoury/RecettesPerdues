using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookable : MonoBehaviour
{
    public GameObject 	casserole;
    public bool       	inCasserole = false;

    private void OnMouseUp() {
    	if (Input.GetMouseButtonUp(0)) {

            // Check if in casserole
            if (transform.GetChild(0).GetComponent<Collider2D>().IsTouching(casserole.GetComponent<Collider2D>())) {
                this.gameObject.transform.parent = casserole.transform.GetChild(0);
                this.GetComponent<Collider2D>().enabled = false;
                inCasserole = true;
                
            }

        }
    }

    void	Update()
    {
    }


 }
