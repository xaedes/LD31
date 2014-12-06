using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelLoader : MonoBehaviour
{
	Text text;
	public Transform wall;
	// Use this for initialization
	void Start()
	{
		text = GetComponent <Text>();

		string str = text.text;

		var lines = str.Split('\n');
		int height = lines.Length;

		float blocksize = 4f;
		for (int j = 0; j < height; j++) {
			int width = lines [j].Length;
			for (int i = 0; i < width; i++) {
				switch (lines [j] [i]) {
					case 'w':
						Instantiate(wall, new Vector3(i * blocksize, 0, j * blocksize), Quaternion.identity);
						break;
					case 'A':
						break;
					case 'b':
						break;
					case 'B':
						break;
					case 'E':
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




