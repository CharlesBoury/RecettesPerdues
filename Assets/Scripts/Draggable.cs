﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    public Animator     animator;
	  bool                isHeld = false;
    public bool         inCasserole = false;
    Vector3             offset;
    Vector3             initialPosition;
    public bool         getBackToOrigin = false;
    public bool         enable = true;

    void Start()
    {
      initialPosition = transform.position;
    }

    private Vector3 getWorldMouse()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return  new Vector3(
                mouseWorldPos.x,
                mouseWorldPos.y,
                0);
    }
    // Start is called before the first frame update
    private void OnMouseDown() {
    	if (Input.GetMouseButtonDown(0) && enable == true) {
            Vector3 mouseWorldPos = getWorldMouse();
    		    isHeld = true;
            offset = this.gameObject.transform.localPosition - mouseWorldPos;
            if (animator != null) {
              animator.SetBool("Content", true);
            }
        }
    }
    private void OnMouseUp() {
    	if (Input.GetMouseButtonUp(0)) {
    		    isHeld = false;
            if (animator != null) {
              animator.SetBool("Content", false);
            }
            if (getBackToOrigin) {
              transform.position = initialPosition;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isHeld) {
        	Vector3 mouseWorldPos = getWorldMouse();
        	this.gameObject.transform.localPosition = new Vector3(mouseWorldPos.x + offset.x, mouseWorldPos.y +     offset.y, 0);
        }
    }
}
