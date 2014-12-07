using UnityEngine;
using System.Collections;

public class Exploding : MonoBehaviour
{
	public int bombStrength = 1;                 // The strength of the bomb.
	public float countdown = 1;                  // Time until explode in seconds.
	public Transform flame;                      // Flame object to spawn after explosion.
	public Transform explosion;                  // Explosion object to spawn after explosion for audio playing.

	// Use this for initialization
	void Start()
	{

		// Let the bomb explode after <countdown> seconds
		Invoke("Explode", countdown);
	}
	
	// When destroyed, spawn Flame
	void Explode()
	{
		// Spawn flame
		if (flame != null) {
			Transform flameClone = (Transform)Instantiate(flame, transform.position, Quaternion.identity);
			
			// Set strength of flame according to bomb strength
			flameClone.GetComponent<Spreading>().range = bombStrength;
		}

		// Spawn explosion
		if (explosion != null) {
			Instantiate(explosion);
		}

		// Destruct bomb
		Destroy(this.gameObject);
	}
}
