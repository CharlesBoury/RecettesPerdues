using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casserole : MonoBehaviour
{

	public List<AudioClip> lstBloupsAudio;
	AudioSource audioSource;

	void Start() {
			audioSource = transform.GetComponent<AudioSource>();
	}

	public void PlayBloup() {
		if (!audioSource.isPlaying)
		{
				audioSource.clip = lstBloupsAudio[Random.Range(0, lstBloupsAudio.Count)];
				audioSource.Play();
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
		other.GetComponent<SpriteRenderer>().color = Color.blue;
	}
	private void OnTriggerExit2D(Collider2D other) {
		other.GetComponent<SpriteRenderer>().color = Color.white;
	}
}
