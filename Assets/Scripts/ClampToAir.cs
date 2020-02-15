using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampToAir : MonoBehaviour
{
	public GameObject	casserole;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	if (transform.localPosition.x >= casserole.transform.localPosition.x - casserole.GetComponent<SpriteRenderer>().size.x / 2)
    	{
    		transform.localPosition = new Vector3(
        	transform.localPosition.x,
        	Mathf.Clamp(transform.localPosition.y, 3, 7),
        	0);
        	Debug.Log("cc");
    	}
        

    }
}
