using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour
{
	public static float blocksize = 4.0f;

	public static Vector3 LEFT { get { return new Vector3(-Grid.blocksize,0,0); } }
	public static Vector3 RIGHT { get { return new Vector3(+Grid.blocksize,0,0); } }
	public static Vector3 UP { get { return new Vector3(0,-Grid.blocksize,0); } }
	public static Vector3 DOWN { get { return new Vector3(0,+Grid.blocksize,0); } }


	public static Vector3 round(Vector3 vec)
	{
		Vector3 res;
		res.x = Mathf.RoundToInt(vec.x / Grid.blocksize) * Grid.blocksize;
		res.y = vec.y;
		res.z = Mathf.RoundToInt(vec.z / Grid.blocksize) * Grid.blocksize;
		return res;
	}

	public static Vector3[] Neighbors4(Vector3 of) {
		Vector3[] neighbors = new Vector3[4];
		neighbors[0] = of + LEFT;
		neighbors[1] = of + RIGHT;
		neighbors[2] = of + UP;
		neighbors[3] = of + DOWN;
		return neighbors;
	}
}
