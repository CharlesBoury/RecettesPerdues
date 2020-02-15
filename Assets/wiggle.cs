using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wiggle : MonoBehaviour
{

	public	GameObject	go;
	public	Transform	tr;
	public	Time		time;
    // Start is called before the first frame update
    void Start()
    {
        //while (true)
        //{
        	this.tr.Rotate(0, 0, 90);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
