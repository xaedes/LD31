using UnityEngine;
using System.Collections;

public class SnapToGrid : MonoBehaviour
{
	public float smoothness = 0.01f;
	
	// Update is called once per frame
	void FixedUpdate()
	{
		transform.position = Vector3.Lerp(transform.position, Grid.round(transform.position), smoothness * Time.deltaTime);
	}
}
