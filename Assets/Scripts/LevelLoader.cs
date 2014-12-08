using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class LevelLoader : MonoBehaviour
{
	public Transform wall;
	public Transform player;
	public Transform box;
	public Transform bomb;
	public Transform enemy;
	public Transform flame;
	public Transform highlightTargetCell;
	public Transform spawn;
	public Transform portal;
	public Transform text;

	public List<Transform> texts = new List<Transform>();

	public GameObject InstantiateAsChild(Transform template, Vector3 position, Quaternion rotation) {
		GameObject a = ((Transform)Instantiate(template, position, rotation)).gameObject;
		a.transform.parent = transform;
		return a;
	}

	public Vector3 Pos(int i, int j)
	{
		return new Vector3(i * Grid.blocksize, 0, -j * Grid.blocksize);
	}

    public void LoadLevel(string map)
	{
		var lines = map.Split('\n');
		int height = lines.Length;
		
		GameObject a,b;
		for (int j = 0; j < height; j++) {
			int width = lines [j].Length;
			for (int i = 0; i < width; i++) {
				Vector3 pos = Pos(i,j);
				switch (lines [j] [i]) {
					case 'w':
						InstantiateAsChild(wall, pos, Quaternion.identity);
						break;
					case 'A':
						a = InstantiateAsChild(player, pos, Quaternion.identity); 
						b = InstantiateAsChild(highlightTargetCell, pos, Quaternion.identity);
						b.GetComponent<GridPositionOf>().target = a.transform;
						break;
					case 'b':
						InstantiateAsChild(box, pos, Quaternion.identity); 
						break;
					case 'F':
						InstantiateAsChild(flame, pos, Quaternion.identity); 
						break;
					case 'B':
						InstantiateAsChild(bomb, pos, Quaternion.identity); 
						break;
					case 's':
						a = InstantiateAsChild(spawn, pos, Quaternion.identity); 
						a.GetComponent<EnemySpawn>().enemy = enemy;
						break;
					case 'P':
						a = InstantiateAsChild(portal, pos, Quaternion.identity); 
						//						a.GetComponent<EnemySpawn>().enemy = enemy;
						break;
					case 't':
						a = InstantiateAsChild(text, pos, Quaternion.identity); 
						texts.Add(a.transform);
						break;
					default:
						break;
				}	

			}
		}
	}

	public void DestroyChildren()
	{
		foreach (Transform child in transform) {
			GameObject.Destroy(child.gameObject);
		}
		texts.Clear();
	}
}




