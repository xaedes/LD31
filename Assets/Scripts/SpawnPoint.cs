using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour
{
	public Transform spawn;
	public float interval;
	float timer;

	// Use this for initialization
	void Start()
	{
		timer = 0;
	}
	
	// Update is called once per frame
	void Update()
	{
		if (spawn != null) {
			timer += Time.deltaTime;
			if (timer > interval) {
				Transform spawned = (Transform)Instantiate(spawn, transform.position, Quaternion.identity);
				spawned.parent = transform.parent;
				timer = 0;
			}
		}
	}
}
