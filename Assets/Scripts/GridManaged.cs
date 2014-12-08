using UnityEngine;
using System.Collections;

public class GridManaged : MonoBehaviour
{
	int index = -1;
	Grid grid;

	// Use this for initialization
	void Start()
	{
		grid = GameObject.FindGameObjectWithTag("Grid").GetComponent<Grid>();
		index = Grid.index(Grid.round(transform.position));
		grid.addObject(this.gameObject);
		this.gameObject.SendMessage("OnGridPlaced", SendMessageOptions.DontRequireReceiver);
	}
	
	// Update is called once per frame
	void Update()
	{
		int newIndex = Grid.index(Grid.round(transform.position));
		if (newIndex != index) {
			grid.removeObject(this.gameObject, index);
			index = newIndex;
			grid.addObject(this.gameObject);
			this.gameObject.SendMessage("OnGridMove", SendMessageOptions.DontRequireReceiver);
		}
	}

	public void OnDestroy()
	{
		this.gameObject.SendMessage("OnGridRemoved", SendMessageOptions.DontRequireReceiver);
		if (grid == null) {
			grid = GameObject.FindGameObjectWithTag("Grid").GetComponent<Grid>();
		}
		if (grid != null) {
			grid.removeObject(this.gameObject);
		}
	}

	public int Index {
		get {
			return index;
		}
	}
}
