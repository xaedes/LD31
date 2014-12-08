using UnityEngine;
using System.Collections;

public class CameraFollower : MonoBehaviour
{
	public Transform initialTarget;
	public float smoothing = 5f;        // The speed with which the camera will be following.
	Transform target;            
	
	Vector3 offset;                     // The initial offset from the target.

	// Use this for initialization
	void Start()
	{
		// Calculate the initial offset.
		offset = transform.position - initialTarget.position;
		FindTarget();
	}

	void FindTarget()
	{
		GameObject t = GameObject.FindGameObjectWithTag("Player");
		if (t != null) {
			target = t.transform;
		}
		
	}

	void FixedUpdate()
	{
		if (target == null) {
			FindTarget();
		}
		if (target != null) {
			// Create a postion the camera is aiming for based on the offset from the target.
			Vector3 targetCamPos = target.position + offset;
		
			// Smoothly interpolate between the camera's current position and it's target position.
			transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
		}
	}
}
