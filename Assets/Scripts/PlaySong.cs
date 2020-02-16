using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySong : MonoBehaviour
{

	public List<AudioClip> lstBloupsAudio;
	AudioSource audioSource;

	void Start() {
			audioSource = transform.GetComponent<AudioSource>();
	}

	public void PlayBloup() {
		int chosen = Random.Range(0, lstBloupsAudio.Count);
		audioSource.clip = lstBloupsAudio[chosen];
		audioSource.Play();
	}
}
