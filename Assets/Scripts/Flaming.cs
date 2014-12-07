using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Flaming : MonoBehaviour
{
	HashSet<GameObject> flamed;

	void Awake()
	{
		flamed = new HashSet<GameObject>();
	}

	void OnTriggerEnter(Collider other)
	{
		OnTriggerStay(other);
	}

	void OnTriggerStay(Collider other)
	{
		if (!flamed.Contains(other.gameObject)) {
			other.gameObject.SendMessage("OnFlame", (Object)this, SendMessageOptions.DontRequireReceiver);
			flamed.Add(other.gameObject);
		}
	}

}
