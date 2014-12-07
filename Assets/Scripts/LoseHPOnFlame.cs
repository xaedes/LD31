using UnityEngine;
using System.Collections;

public class LoseHPOnFlame : MonoBehaviour {
	Health health;

	// Use this for initialization
	void Start () {
		health = GetComponent<Health>();
	}

	public void OnFlame(Object flame)
	{
		health.hp -= 1;
	}
}
