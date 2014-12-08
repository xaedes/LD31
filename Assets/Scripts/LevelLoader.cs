using UnityEngine;
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
						Instantiate(player, pos, Quaternion.identity);
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
					case 'E':
						Instantiate(enemy, pos, Quaternion.identity);
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




