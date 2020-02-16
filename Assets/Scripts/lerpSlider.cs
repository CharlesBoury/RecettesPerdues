using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class lerpSlider : MonoBehaviour
{
	public float speed = 0.05f;
	public float value = 0;
	float currentValue = 0;

	void OnEnable() {
		value = 0;
		currentValue = 0;
	}
	void Update() {
		if (currentValue < value) {
			currentValue+= Time.deltaTime * speed;
			currentValue = Mathf.Clamp(currentValue, 0, 1);
			this.GetComponent<Slider>().value = currentValue;

			if (currentValue >= value)
				this.GetComponent<AudioSource>().Play();
		}
	}
}
