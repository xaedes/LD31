using UnityEngine;
using System.Collections;

public class DropBomb : MonoBehaviour
{
	public int bombStrength = 1;                  // The strength of the to-be-dropped bomb.
	public float timeBetweenBombs = 0.15f;        	// The time between each bomb.
	
	public Transform bomb;							// Bomb object to drop.
	
	float timer;                                    // A timer to determine when to drop bombs.
	
	void Update()
	{
		// Add the time since Update was last called to the timer.
		timer += Time.deltaTime;
	}
	
	public bool Drop()
	{
		// Check if dropping is allowed by timer
		if (timer >= timeBetweenBombs) {
			// Reset the timer.
			timer = 0;
		
			// Compute position of bomb
			Vector3 position = Grid.round(transform.position);
		
			// Instantiate the bomb
			Transform dropped = (Transform)Instantiate(bomb, position, Quaternion.identity);
			dropped.transform.parent = transform.parent;
		
			// Set bomb strength
			Exploding expl = dropped.GetComponent< Exploding >();
			expl.bombStrength = bombStrength;

			return true;
		} else
			return false;
	}
}
