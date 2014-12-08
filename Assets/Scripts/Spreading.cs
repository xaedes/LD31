using UnityEngine;
using System.Collections;

public class Spreading : MonoBehaviour
{
	public int range;	        // how often to spread (0 = no spreading at all, 1 = spreading into neighboring tiles)
	public float delay;         // wait this long until spreading continues
	public float afterBurnTime; // after spreading, let the flame alive for this long
	public int predefinedDirection = -1;

	void Start()
	{
		Invoke("Spread", delay);
	}
	
	void Spread()
	{
		if (range > 0) {
			Vector3[] ns = Grid.Neighbors4(transform.position);
			if (predefinedDirection < 0) {
				for (int i =0; i < ns.Length; i++) {
					Vector3 position = ns [i];
					GameObject clone = (GameObject)Instantiate(this.gameObject, position, Quaternion.identity);
					clone.transform.parent = transform.parent;
					Spreading spreading = clone.GetComponent<Spreading>();
					spreading.range = range - 1;
					spreading.predefinedDirection = i;
				}
			} else {
				Vector3 position = ns [predefinedDirection];
				GameObject clone = (GameObject)Instantiate(this.gameObject, position, Quaternion.identity);
				clone.transform.parent = transform.parent;
				clone.GetComponent<Spreading>().range = range - 1;
			}
		}
		Destroy(this.gameObject, afterBurnTime);
	}

	void OnTriggerEnter(Collider other)
	{
		OnTriggerStay(other);
	}
	
	void OnTriggerStay(Collider other)
	{
		// Collisions stop further spreading
		range = 0;
	}
}
