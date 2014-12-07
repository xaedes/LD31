using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grid : MonoBehaviour
{
	public static float blocksize = 4.0f;

	public static Vector3 LEFT { get { return new Vector3(-Grid.blocksize, 0, 0); } }

	public static Vector3 RIGHT { get { return new Vector3(+Grid.blocksize, 0, 0); } }

	public static Vector3 UP { get { return new Vector3(0, 0, -Grid.blocksize); } }

	public static Vector3 DOWN { get { return new Vector3(0, 0, +Grid.blocksize); } }

	public static Vector3 round(Vector3 vec)
	{
		Vector3 res;
		res.x = Mathf.RoundToInt(vec.x / Grid.blocksize) * Grid.blocksize;
		res.y = vec.y;
		res.z = Mathf.RoundToInt(vec.z / Grid.blocksize) * Grid.blocksize;
		return res;
	}

	public static Vector3[] Neighbors4(Vector3 of)
	{
		Vector3[] neighbors = new Vector3[4];
		neighbors [0] = of + LEFT;
		neighbors [1] = of + RIGHT;
		neighbors [2] = of + UP;
		neighbors [3] = of + DOWN;
		return neighbors;
	}

	public static int max_columns = 1000;

	Dictionary<int, List<GameObject>> objects;

	public void Awake() {
		objects = new Dictionary<int, List<GameObject>>();
	}

	public static int index(GameObject obj) {
		Transform transform = obj.GetComponent<Transform>();
		return Grid.index(Grid.round(transform.position));
	}
	public static int index(Vector3 pos) {
		return (int)(pos.x  +  pos.z  * max_columns);
	}

	public void removeObject(GameObject obj)
	{
		removeObject(obj, Grid.index(obj));
	}
	public void removeObject(GameObject obj, int idx)
	{
		if(!objects.ContainsKey(idx)) {
			objects[idx].Remove(obj);
		}
	}
	public void addObject(GameObject obj)
	{
		int idx  = Grid.index(obj);
		if(!objects.ContainsKey(idx)) {
			objects.Add(idx, new List<GameObject>());
		}
		objects[idx].Add(obj);
	}


}
