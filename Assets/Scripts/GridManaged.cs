using UnityEngine;
using System.Collections;

public class GridManaged : MonoBehaviour {
	int index = -1; 
	Grid grid;

	// Use this for initialization
	void Start () {
		grid = GameObject.FindGameObjectWithTag ("Grid").GetComponent<Grid>();
		index = Grid.index(Grid.round(transform.position));
		grid.addObject(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		int newIndex = Grid.index(Grid.round(transform.position));
		if(newIndex != index) {
			Debug.Log("Moved");
			Debug.Log(this.gameObject);
			grid.removeObject(this.gameObject, index);
			index = newIndex;
			grid.addObject(this.gameObject);
		}
	}

	public void OnDestroy() 
	{
		Debug.Log("Removed");
		Debug.Log(this.gameObject);
		grid.removeObject(this.gameObject);
	}
}
