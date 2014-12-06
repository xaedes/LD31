using UnityEngine;
using System.Collections;

public class SnapToGrid : MonoBehaviour
{
	public float blocksize = 4f;
	public float smoothness = 0.01f;
	
	// Use this for initialization
	void Start()
	{
	
	}
	
	// Update is called once per frame
	void FixedUpdate()
	{
		Vector3 tilePos = transform.position / blocksize;
		Vector3 target = transform.position;

		if (Mathf.Abs(tilePos.x - Mathf.RoundToInt(tilePos.x)) >
			Mathf.Abs(tilePos.z - Mathf.RoundToInt(tilePos.z))) {
			target =  new Vector3(transform.position.x, transform.position.y, Mathf.RoundToInt(tilePos.z)*blocksize);
		} else 
		if (Mathf.Abs(tilePos.x - Mathf.RoundToInt(tilePos.x)) <
			Mathf.Abs(tilePos.z - Mathf.RoundToInt(tilePos.z))) {
			target = new Vector3(Mathf.RoundToInt(tilePos.x)*blocksize, transform.position.y, transform.position.z);
		}
		transform.position = Vector3.Lerp(transform.position, target, smoothness * Time.deltaTime);
	}
}
