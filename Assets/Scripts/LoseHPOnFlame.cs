using UnityEngine;
using System.Collections;

public class LoseHPOnFlame : MonoBehaviour
{
	Health health;
	AudioSource audio;

	// Use this for initialization
	void Start()
	{
		health = GetComponent<Health>();
		audio = GetComponent<AudioSource>();
	}

	public void OnFlame(Object flame)
	{
		health.hp -= 1;
		if (audio != null) {
			audio.Play();
		}
	}
}
