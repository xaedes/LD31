using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Flaming : MonoBehaviour
{
	HashSet<GameObject> flamed;
	Grid grid;
	GridManaged gridManaged;

	void Awake()
	{
		flamed = new HashSet<GameObject>();
		grid = GameObject.FindGameObjectWithTag("Grid").GetComponent<Grid>();
		gridManaged = GetComponent<GridManaged>();
	}

	void OnGridCollision()
	{

		foreach (GameObject other in grid[gridManaged.Index]) {
			if (other != this.gameObject) {
				if (!flamed.Contains(other)) {
					other.SendMessage("OnFlame", (Object)this, SendMessageOptions.DontRequireReceiver);
					flamed.Add(other);
				}
			}
		}
	}

}
