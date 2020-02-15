using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casserole : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D other) {
		other.GetComponent<SpriteRenderer>().color = Color.blue;
	}
	private void OnTriggerExit2D(Collider2D other) {
		other.GetComponent<SpriteRenderer>().color = Color.white;
	}
}
