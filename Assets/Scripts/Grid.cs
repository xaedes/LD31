using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Grid : MonoBehaviour
{
	public static float blocksize = 4.0f;
	public static readonly Vector3 LEFT = new Vector3(-Grid.blocksize, 0, 0);
	public static readonly Vector3 RIGHT = new Vector3(+Grid.blocksize, 0, 0);
	public static readonly Vector3 UP = new Vector3(0, 0, -Grid.blocksize);
	public static readonly Vector3 DOWN = new Vector3(0, 0, +Grid.blocksize);

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
	float maxX = -2 * max_columns * blocksize;
	float maxY = -2 * max_columns * blocksize;
	float minX = +2 * max_columns * blocksize;
	float minY = +2 * max_columns * blocksize;

	public void Awake()
	{
		objects = new Dictionary<int, List<GameObject>>();
	}

	public static int index(GameObject obj)
	{
		Transform transform = obj.GetComponent<Transform>();
		return Grid.index(Grid.round(transform.position));
	}

	public static int index(Vector3 pos)
	{
		return (int)(pos.x / blocksize + (pos.z / blocksize) * max_columns);
	}

	public static Vector3 positionFromIndex(int idx)
	{
		int x = idx % max_columns;
		int y = (idx - x) / max_columns;
		return new Vector3(x, 0f, y) * blocksize;
	}

	public void removeObject(GameObject obj)
	{
		removeObject(obj, Grid.index(obj));
	}

	public void removeObject(GameObject obj, int idx)
	{
		if (objects == null)
			return;

		if (objects.ContainsKey(idx)) {
			objects [idx].Remove(obj);
		}
	}

	public void updateBounds(GameObject obj)
	{
		Transform transform = obj.GetComponent<Transform>();
		Vector3 pos = Grid.round(transform.position);
		float x = pos.x;
		float y = pos.z;
		if (maxX < x)
			maxX = x;
		if (maxY < y)
			maxY = y;
		if (minX > x)
			minX = x;
		if (minY > y)
			minY = y;
	}

	public void addObject(GameObject obj)
	{
		updateBounds(obj);
		int idx = Grid.index(obj);
		if (!objects.ContainsKey(idx)) {
			objects.Add(idx, new List<GameObject>());
		}
		objects [idx].Add(obj);
		foreach(GameObject o in objects [idx]){
			o.SendMessage("OnGridCollision",SendMessageOptions.DontRequireReceiver);
		}
	}

	public bool IsWalkable(int idx)
	{
		if (!IsEmpty(idx)) {
			return objects [idx].Where(o => o.GetComponent<NotWalkable>() != null).Count()==0;
		} else {
			return true;
		}
	}

	public bool IsEmpty(int idx)
	{
		if (objects.ContainsKey(idx)) {
			return objects [idx].Count == 0;
		} else {
			return true;
		}
	}

	public Vector3[] EmptyNeighbors4(Vector3 of)
	{
		Vector3[] neighbors = Grid.Neighbors4(of);
		return neighbors.Where(n => IsEmpty(index(n))).ToArray();
	}

	public float Width { 
		get {
			return maxX - minX;
		}
	}

	public float Height { 
		get {
			return maxX - minX;
		}
	}

	public float MinX { 
		get {
			return minX;
		}
	}
	
	public float MinY { 
		get {
			return minY;
		}
	}

	public float MaxX { 
		get {
			return maxX;
		}
	}
	
	public float MaxY { 
		get {
			return maxY;
		}
	}

	public List<GameObject> this [int idx] {
		get {
			if (objects.ContainsKey(idx))
				return objects [idx];
			else {
				objects [idx] = new List<GameObject>();
				return objects [idx];
			}
		}
	}
}
