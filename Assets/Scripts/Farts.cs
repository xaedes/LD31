using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Farts : MonoBehaviour
{
	public float diffusion = 0.5f;
	Grid grid;
	HasGridValues values;
	
	// Use this for initialization
	void Start()
	{
		grid = GameObject.FindGameObjectWithTag("Grid").GetComponent<Grid>();
		values = GetComponent<HasGridValues>();
		
	}
	
	// Update is called once per frame
	void Update()
	{
//		Diffuse();
	}

	void Diffuse()
	{
		List<int> indices = values.Indices("fart");
		HashSet<int> all_indices = new HashSet<int>(indices);
		foreach (int idx in indices) {
			int[] neighbors = Grid.Neighbors4(Grid.positionFromIndex(idx))
				.Where(n => (n.x >= grid.MinX) && (n.x <= grid.MaxX) && (n.y >= grid.MinY) && (n.y <= grid.MaxY))
					.Select(n => Grid.index(n))
					.ToArray();
			all_indices.UnionWith(neighbors);
		}
		foreach (int idx in all_indices) {
			float[] neighbors = Grid.Neighbors4(Grid.positionFromIndex(idx))
				.Select(n => values ["fart", Grid.index(n)])
				.ToArray();
			float average = neighbors.Length == 0 ? 0 : neighbors.Average();

			values ["diffused", idx] = diffusion * average + (1f - diffusion) * values ["fart", idx];
		}
		values ["fart"] = values ["diffused"];
	}

	public void OnGridPlaced()
	{
		OnGridMove();
	}

	public void OnGridMove()
	{
		int idx = Grid.index(this.gameObject);
		values ["fart", idx] += 1;
		Diffuse();
	}
}
