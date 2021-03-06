﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelLoader : MonoBehaviour
{
	Text text;
	public Transform wall;
	public Transform player;
	public Transform box;
	public Transform bomb;
	public Transform enemy;
	public Transform flame;
	public Transform highlightTargetCell;
	public Transform spawn;

	// Use this for initialization
	void Awake()
	{
		text = GetComponent <Text>();

		string str = text.text;

		var lines = str.Split('\n');
		int height = lines.Length;

		float blocksize = 4f;
		for (int j = 0; j < height; j++) {
			int width = lines [j].Length;
			for (int i = 0; i < width; i++) {
				Vector3 pos = new Vector3(i * blocksize, 0, j * blocksize);
				switch (lines [j] [i]) {
					case 'w':
						Instantiate(wall, pos, Quaternion.identity);
						break;
					case 'A':
						GameObject p = ((Transform)Instantiate(player, pos, Quaternion.identity)).gameObject;
						GameObject b = ((Transform)Instantiate(highlightTargetCell, pos, Quaternion.identity)).gameObject;
						b.GetComponent<GridPositionOf>().target = p.transform;
						break;
					case 'b':
						Instantiate(box, pos, Quaternion.identity);
						break;
					case 'F':
						Instantiate(flame, pos, Quaternion.identity);
						break;
					case 'B':
						Instantiate(bomb, pos, Quaternion.identity);
						break;
					case 's':
						GameObject s = ((Transform)Instantiate(spawn, pos, Quaternion.identity)).gameObject;
						s.GetComponent<EnemySpawn>().enemy = enemy;
						break;
						break;
					default:
						break;
				}	

			}
		}

	}
    
	// Update is called once per frame
	void Update()
	{
//  text.text = "Score: ";
	}
}




