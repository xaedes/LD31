using UnityEngine;
using System.Collections;

public class PlayerDropBomb : MonoBehaviour
{
	public DropBomb dropBomb;							

	void Awake() 
	{
		dropBomb = GetComponent<DropBomb>();
	}

	// Update is called once per frame
	void Update()
	{
		// If the Fire1 button is being pressed,  it's time to bomb...
		if (Input.GetButton("Fire1")) {
			dropBomb.Drop();
		}
	}

	public void OnDeath() 
	{
		enabled = false;
	}
}
