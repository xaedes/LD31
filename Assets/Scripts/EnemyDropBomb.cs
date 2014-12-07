using UnityEngine;
using System.Collections;

public class EnemyDropBomb : MonoBehaviour
{
	public DropBomb dropBomb;							
	
	void Awake()
	{
		dropBomb = GetComponent<DropBomb>();
	
	}
	
	// Update is called once per frame
	void Update()
	{
		if(Random.Range(0f,1f) < 0.01f) {
			dropBomb.Drop();
		}
	}
}
