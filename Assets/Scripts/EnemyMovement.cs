﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MoreLinq;

public class EnemyMovement : MonoBehaviour
{
	public float speed;
	NavMeshAgent nav;
	Rigidbody rigid;
	Animator anim;
	Vector3 target;
	Vector3 movement;
	Grid grid;
	HasGridValues values;
	const float movingThreshold = 1e-2f;
	const float stopOnDistance = 0.1f;

	// Use this for initialization
	void Awake()
	{
		nav = GetComponent <NavMeshAgent>();
		anim = GetComponent <Animator>();
		rigid = GetComponent <Rigidbody>();
		target = transform.position;
		grid = GameObject.FindGameObjectWithTag("Grid").GetComponent<Grid>();
		values = GetComponent<HasGridValues>();
	}
	
	// Update is called once per frame
	void Update()
	{
		Animating();
		if (movement.magnitude < stopOnDistance) {
			SelectTarget();
		}

	}

	// Update is called once per frame
	void FixedUpdate()
	{
		movement = target - transform.position;
		movement.y = 0;
		if (movement.magnitude > movingThreshold) {
			float length = Time.deltaTime * speed;

			if( movement.magnitude < length ) {
				length = movement.magnitude;
			}
			movement = movement.normalized * length;
			transform.position += movement;
		} else {
			movement = Vector3.zero;
		}
	}

	void SelectTarget()
	{
		Vector3[] ns = grid.EmptyNeighbors4(Grid.round(transform.position));


		if (ns.Length > 0) {
			target = ns.MinBy(n => values ["fart", Grid.index(n)]);
//			target = ns[Random.Range(0,ns.Length-1)];
		}
	}

	void Animating()
	{
		bool walking = movement.magnitude > movingThreshold;
		anim.SetBool("IsWalking", walking);
	}
}
