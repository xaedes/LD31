﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MoreLinq;

public class PlayerMovement : MonoBehaviour
{
	Animator anim;                      // Reference to the animator component.
	Vector3 movement;
	public float speed = 15f;
	public float rotationSpeed = 10f;
	Quaternion targetRotation;
	Grid grid;

	// Use this for initialization
	void Awake()
	{
		// Set up references.
		anim = GetComponent <Animator>();
		targetRotation = transform.rotation;
		grid = GameObject.FindGameObjectWithTag("Grid").GetComponent<Grid>();
	}
	
	void FixedUpdate()
	{
		// Store the input axes.
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");

		movement.Set(0, 0, 0);
		// Move the player around the scene.
		Move(h, v);
		
		// Turn the player to face the mouse cursor.
		Turning(h, v);
		
		// Animate the player.
		Animating(h, v);
	}

	void Move(float h, float v)
	{
		// Move the player to it's current position plus the movement.
		movement += (new Vector3(h, 0f, v)).normalized * speed * Time.deltaTime;


		Vector3 update = transform.position + movement;
		int updatedIndex = Grid.index(Grid.round(update));
		// avoid collisions
		bool collision = false;
		if(updatedIndex == GetComponent<GridManaged>().Index || grid.IsWalkable(updatedIndex)) {
			transform.position = update;
		}
	}

	void Turning(float h, float v)
	{
		if (Mathf.Abs(h) > 1e-3 || Mathf.Abs(v) > 1e-3) {
			if (Mathf.Abs(h) > Mathf.Abs(v)) {
				if (h > 0) {
					// right
					targetRotation = Quaternion.AngleAxis(90, Vector3.up);
				} else {
					//left
					targetRotation = Quaternion.AngleAxis(270, Vector3.up);
				}
			} else {
				if (v > 0) {
					// top
					targetRotation = Quaternion.AngleAxis(0, Vector3.up);
				} else {
					// down
					targetRotation = Quaternion.AngleAxis(180, Vector3.up);
				}
			}
		}
		transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

	}

	void Animating(float h, float v)
	{
		// Create a boolean that is true if either of the input axes is non-zero.
		bool walking = h != 0f || v != 0f;
		
		// Tell the animator whether or not the player is walking.
		anim.SetBool("IsWalking", walking);
	}

	public void OnDeath()
	{
		anim.SetBool("IsDead", true);
		enabled = false;
	}


}
