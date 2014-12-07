using UnityEngine;
using System.Collections;

public class FlameDestroying : MonoBehaviour {
	int flameDestroyableMask;                              

	void Awake () {
		flameDestroyableMask = LayerMask.GetMask ("FlameDestroyable");
	}

	// Destroy everything that enters the trigger
	void OnTriggerEnter (Collider other) {
		if(other.gameObject.layer == flameDestroyableMask) {
			Destroy(other.gameObject);
		}
	}
}
