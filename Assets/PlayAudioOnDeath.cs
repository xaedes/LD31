using UnityEngine;
using System.Collections;

public class PlayAudioOnDeath : MonoBehaviour
{
	public AudioClip deathClip;
	public float wait;

	void OnDeath()
	{
//		audio.Stop();
//		audio.clip = deathClip;
//		audio.Play();
		Invoke("play",wait);

	}

	void play()
	{audio.PlayOneShot(deathClip);
	}

}
