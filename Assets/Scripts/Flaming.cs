using UnityEngine;
using System.Collections;

public class Flaming : MonoBehaviour
{
	void Awake()
	{
	}

	void OnTriggerEnter(Collider other)
	{
		OnTriggerStay(other);
	}

	void OnTriggerStay(Collider other)
	{
		other.gameObject.SendMessage("OnFlame", (Object) this, SendMessageOptions.DontRequireReceiver);
	}

}
