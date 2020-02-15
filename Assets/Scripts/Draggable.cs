using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
	bool isHeld = false;
    // Start is called before the first frame update
    private void OnMouseDown() {
    	if (Input.GetMouseButtonDown(0)) {
    		isHeld = true;
    	}
    }
    private void OnMouseUp() {
    	if (Input.GetMouseButtonUp(0)) {
    		isHeld = false;
    	}
    }

    // Update is called once per frame
    void Update()
    {
        if (isHeld) {
        	Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        	mouseWorldPos = new Vector3(
        		mouseWorldPos.x, 
        		mouseWorldPos.y, 
        		0);

        	this.gameObject.transform.localPosition = mouseWorldPos;
        }
    }
}
