using UnityEngine;
using System.Collections;

public class DestroyOnCollision : MonoBehaviour {
	Grid grid;
	GridManaged gridManaged;
	
	// Use this for initialization
	void Start () {
		grid = GameObject.FindGameObjectWithTag("Grid").GetComponent<Grid>();
		gridManaged = GetComponent<GridManaged>();
	}
	
	void OnGridCollision()
	{
		if(grid==null || gridManaged == null) return;
		foreach (GameObject other in grid[gridManaged.Index]) {
			if (other != gameObject) {
				Destroy(gameObject);
				break;
			}
		}
	}
}
