using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class parlotte : MonoBehaviour
{
    public AudioClip audioClip;
    AudioSource audioSource;

    private void OnMouseDown() {
    	if (Input.GetMouseButtonDown(0)) {
              //audioSource.PlayOneShot(audioSource.clip, 0.5f);
              if (audioClip != null)
              {
                  audioSource.clip = audioClip;
                  audioSource.Play();
              }
              //AudioSource.PlayClipAtPoint(audioClip, transform.position);
      }
    }

    // Start is called before the first frame update
    void Start()
    {
      audioSource = transform.parent.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
