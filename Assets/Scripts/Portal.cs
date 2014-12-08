using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {
	Grid grid;
	GameObject player;
	GridManaged gridManaged;
	
	// Use this for initialization
	void Start () {
		grid = GameObject.FindGameObjectWithTag("Grid").GetComponent<Grid>();
		player = GameObject.FindGameObjectWithTag ("Player");
		gridManaged = GetComponent<GridManaged>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnGridCollision()
	{
		foreach (GameObject other in grid[gridManaged.Index]) {
			if (other == player) {
				grid.SendMessage("NextLevel",SendMessageOptions.DontRequireReceiver);
			}
		}
	}
}
