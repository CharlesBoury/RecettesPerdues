using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class power_picker : MonoBehaviour
{
    private bool			isHeld = false;
    private Vector3			offset;
	public static double	fire_power = 0.5;
	private Vector3			origin;
	private Vector3			max;
	private Vector3			min;
	private Quaternion		origin_rotation;

	void	Start()
	{
		this.origin = this.transform.localPosition;
		this.origin_rotation = transform.localRotation;
		this.min = this.origin + new Vector3(-GetComponent<SpriteRenderer>().size.x, 0, 0);
		this.max = this.origin + new Vector3(GetComponent<SpriteRenderer>().size.x, GetComponent<SpriteRenderer>().size.y, 0);

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
    	if (Input.GetMouseButtonDown(0)) {
            Vector3 mouseWorldPos = getWorldMouse();
    		isHeld = true;
            offset = this.gameObject.transform.localPosition - mouseWorldPos;
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
        	Vector3 mouseWorldPos = getWorldMouse();

        	transform.localPosition = new Vector3(
        		Mathf.Clamp(mouseWorldPos.x + offset.x, min.x, max.x),
        		transform.localPosition.y, 0);
        	transform.localPosition = new Vector3(
        		transform.localPosition.x,
        		origin.y - Mathf.Cos(Mathf.Abs(transform.localPosition.x - origin.x) * 0.65f) + Mathf.Cos(0), 0);
        	transform.localEulerAngles = new Vector3(0, 0, (transform.localPosition.x - origin.x) * 25);
        	fire_power = (transform.localPosition.x - origin.x) / (max.x - min.x) + 0.5;

            //Debug.Log("Puissance: " + fire_power);
        	//Mathf.Clamp(this.gameObject.transform.localPosition.y, this.min.y, this.max.y),
        	//	0);
        	//Debug.Log("New pos = " + transform.localPosition);
        }
    }
}
