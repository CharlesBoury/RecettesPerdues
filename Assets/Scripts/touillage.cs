using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touillage : MonoBehaviour
{
    public Animator     animator;
    public GameObject  gameState;
    // Start is called before the first frame update
    void Start()
    {
    }
    private void OnMouseDown() {
    	if (Input.GetMouseButtonDown(0)) {
            if (animator != null) {
              Debug.Log("todo: run animation once");
              gameState.GetComponent<gameState>().Touille();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
