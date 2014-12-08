using UnityEngine;
using System.Collections;

public class Unlockable : MonoBehaviour {

	void Unlock () {
		Destroy(gameObject);	
	}
}
