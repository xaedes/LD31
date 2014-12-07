using UnityEngine;
using System.Collections;

public class FlameDestroying : MonoBehaviour
{
	int flameDestroyableMask;

	void Awake()
	{
		flameDestroyableMask = LayerMask.GetMask("FlameDestroyable");
	}

	void OnTriggerEnter(Collider other)
	{
		OnTriggerStay(other);
	}

	void OnTriggerStay(Collider other)
	{
		Debug.Log("OnTriggerStay");
		if (((1 << other.gameObject.layer) & flameDestroyableMask) > 0) {
			Destroy(other.gameObject);
		}
	}

}
