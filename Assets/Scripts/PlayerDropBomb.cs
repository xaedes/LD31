using UnityEngine;
using System.Collections;

public class PlayerDropBomb : MonoBehaviour
{
	public int bombStrength = 1;                  // The strength of the to-be-dropped bomb.
	public float timeBetweenBombs = 0.15f;        	// The time between each bomb.

	public Transform bomb;							// Bomb object to drop.

	float timer;                                    // A timer to determine when to drop bombs.

	// Update is called once per frame
	void Update()
	{
		// Add the time since Update was last called to the timer.
		timer += Time.deltaTime;

		// If the Fire1 button is being press and it's time to bomb...
		if (Input.GetButton("Fire1") && timer >= timeBetweenBombs) {
			// ... drop the bomb
			DropBomb();
		}
	}

	void DropBomb()
	{
		// Reset the timer.
		timer = 0;

		// Compute position of bomb
		Vector3 position = Grid.round(transform.position);

		// Instantiate the bomb
		Transform dropped = (Transform) Instantiate(bomb, position, Quaternion.identity);

		// Set bomb strength
		Exploding expl = dropped.GetComponent< Exploding >();
		expl.bombStrength = bombStrength;
	}
}
