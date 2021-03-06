﻿using System.Collections;
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
                casserole.GetComponent<PlaySong>().PlayBloup();
                gameState.GetComponent<gameState>().UpdateAvancee();
                this.GetComponent<Draggable>().enable = false;
                transform.position = new Vector3(Random.Range(-1f, 1f), -0.25f, 0);
                transform.GetChild(0).position = transform.position;
            }

        }
    }

    void	Update()
    {
    }


 }
