using UnityEngine;
using UnityEngine.UI;
using System.Collections;

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

	GameObject instantiateAsChild(Transform template, Vector3 position, Quaternion rotation) {
		GameObject a = ((Transform)Instantiate(template, position, rotation)).gameObject;
		a.transform.parent = transform;
		return a;
	}

    public void LoadLevel(string map)
	{
		var lines = map.Split('\n');
		int height = lines.Length;
		
		float blocksize = 4f;
		GameObject a,b;
		for (int j = 0; j < height; j++) {
			int width = lines [j].Length;
			for (int i = 0; i < width; i++) {
				Vector3 pos = new Vector3(i * blocksize, 0, -j * blocksize);
				switch (lines [j] [i]) {
					case 'w':
						instantiateAsChild(wall, pos, Quaternion.identity);
						break;
					case 'A':
						a = instantiateAsChild(player, pos, Quaternion.identity); 
						b = instantiateAsChild(highlightTargetCell, pos, Quaternion.identity);
						b.GetComponent<GridPositionOf>().target = a.transform;
						break;
					case 'b':
						instantiateAsChild(box, pos, Quaternion.identity); 
						break;
					case 'F':
						instantiateAsChild(flame, pos, Quaternion.identity); 
						break;
					case 'B':
						instantiateAsChild(bomb, pos, Quaternion.identity); 
						break;
					case 's':
						a = instantiateAsChild(spawn, pos, Quaternion.identity); 
						a.GetComponent<EnemySpawn>().enemy = enemy;
						break;
					case 'P':
						a = instantiateAsChild(portal, pos, Quaternion.identity); 
						//						a.GetComponent<EnemySpawn>().enemy = enemy;
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

	}
}




