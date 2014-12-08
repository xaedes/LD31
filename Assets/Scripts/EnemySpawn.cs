using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour
{
	public Transform enemy;
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
		if (enemy != null) {
			timer += Time.deltaTime;
			if (timer > interval) {
				Transform spawned = (Transform)Instantiate(enemy, transform.position, Quaternion.identity);
				spawned.parent = transform.parent;
				timer = 0;
			}
		}
	}
}
