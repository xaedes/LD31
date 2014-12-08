using UnityEngine;
using System.Collections;

public class GridPositionOf : MonoBehaviour {
	public Transform target;
	
	// Update is called once per frame
	void Update () {
		if(target != null)
			transform.position = Grid.round(target.position);
	}
}