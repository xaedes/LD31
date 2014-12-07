using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	NavMeshAgent nav;
	Animator anim;                      

	// Use this for initialization
	void Awake () {
		nav = GetComponent <NavMeshAgent>();
		anim = GetComponent <Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
