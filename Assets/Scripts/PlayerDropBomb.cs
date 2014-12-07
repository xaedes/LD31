using UnityEngine;
using System.Collections;

public class PlayerDropBomb : MonoBehaviour
{
	public float bombStrength = 20;                 // The damage inflicted by each bullet.
	public float timeBetweenBombs = 0.15f;        	// The time between each shot.

	public Transform bomb;							// Bomb Object to drop

	float timer;                                    // A timer to determine when to fire.

	// Update is called once per frame
	void Update()
	{
		// Add the time since Update was last called to the timer.
		timer += Time.deltaTime;

		// If the Fire1 button is being press and it's time to fire...
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
		Vector3 position = transform.position;
		position.x = Mathf.RoundToInt(position.x / Grid.blocksize) * Grid.blocksize;
		position.z = Mathf.RoundToInt(position.z / Grid.blocksize) * Grid.blocksize;

		// Instantiate the bomb
		Instantiate(bomb, position, Quaternion.identity);
	}
}
