using UnityEngine;
using System.Collections;

public class Level3 : BaseLevel
{
	void Start()
	{
		lvl = GetComponent<LevelLoader>();
		string map = "" +
			"wwwwwwwwww\n" +
			"wPtbbbwwww\n" +
			"wwwwbbwwww\n" +
			"wwwwbbwwww\n" +
			"wwwwbbwwww\n" +
			"wwwwbbwwww\n" +
			"wwwwbbwwww\n" +
			"wwwwt wwww\n" +
			"wwwwAwwwww\n" +
			"wwwwwwwwww\n" +
			"wwwwwwwwww\n";
		
		lvl.LoadLevel(map);
		int k = 0;
		lvl.texts [k++].GetComponentInChildren<TextMesh>().text = "Level 4";
		lvl.texts [k++].GetComponentInChildren<TextMesh>().text = "This\nway";
		for (int i = 0; i < lvl.texts.Count; i++) {
			lvl.texts [i].gameObject.AddComponent<DestroyOnCollision>();
		}
	}
}
