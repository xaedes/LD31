using UnityEngine;
using System.Collections;

public class DestroyAfterSound : MonoBehaviour {
	// Destroy after sound is finished
	void Update () {
		if(!audio.isPlaying) {
			Destroy(this.gameObject);
		}
	}
}
