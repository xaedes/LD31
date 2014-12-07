﻿using UnityEngine;
using System.Collections;

public class Exploding : MonoBehaviour
{
	public float bombStrength = 1;                 // The strength of the bomb.
	public float countdown = 1;                    // Time until explode in seconds.
	public Transform flame;                        // Flame object to spawn after explosion.

	// Use this for initialization
	void Start()
	{
		// Destroy this bomb after <countdown> seconds
		Destroy(this.gameObject, countdown);
	}
	
	// When destroyed, spawn Flame
	void OnDestroy()
	{
		if (flame != null) {
			Instantiate(flame, transform.position, Quaternion.identity);
		}
	}
}
