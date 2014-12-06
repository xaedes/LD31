using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	Animator anim;                      // Reference to the animator component.
	Vector3 movement;
	public float speed = 4f;

	// Use this for initialization
	void Awake ()
	{
		// Set up references.
		anim = GetComponent <Animator> ();
	}
	
	// Update is called once per frame
	void Update()
	{

	}

	void FixedUpdate()
	{
		// Store the input axes.
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");

		movement.Set(0,0,0);
		// Move the player around the scene.
		Move (h, v);
		
		// Turn the player to face the mouse cursor.
		Turning ();
		
		// Animate the player.
		Animating (h, v);
	}
	void Move (float h, float v)
	{
		// Move the player to it's current position plus the movement.

		movement += (new Vector3(h,0f,v)).normalized * speed * Time.deltaTime;

		transform.position += movement;
	}
	void Turning ()
	{
		// pass, todo
	}
	void Animating (float h, float v)
	{
		// Create a boolean that is true if either of the input axes is non-zero.
		bool walking = h != 0f || v != 0f;
		
		// Tell the animator whether or not the player is walking.
		anim.SetBool ("IsWalking", walking);
	}
}
