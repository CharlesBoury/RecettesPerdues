using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chaud : MonoBehaviour
{
    public Draggable draggable;
    public AudioClip audioClip;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
      audioSource = transform.parent.GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
      if (audioClip != null)
      {
          audioSource.clip = audioClip;
          audioSource.Play();
      }
    }

    // Update is called once per frame
    void Update()
    {
      if (draggable.inCasserole) {
          if (power_picker.fire_power > 0.9) {
            transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = true;
          }
          else {
            transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
          }
      }

    }
}
