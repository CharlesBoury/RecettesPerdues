using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class parlotte : MonoBehaviour
{
    public AudioClip audioClip;
    AudioSource audioSource;

    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        //audioSource.PlayOneShot(audioSource.clip, 0.5f);
        if (!audioSource.isPlaying && audioClip != null)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }
        //AudioSource.PlayClipAtPoint(audioClip, transform.position);

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
