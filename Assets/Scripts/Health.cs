using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public int hp;
	Animator anim;                      // Reference to the animator component.
	
	// Use this for initialization
	void Start () {
		anim = GetComponent <Animator>();
	
	}
	
	// Update is called once per frame
	void Update () {
		if(hp<=0) {
			hp = 0;
			gameObject.SendMessage("OnDeath",SendMessageOptions.DontRequireReceiver);
		}
	}
}
