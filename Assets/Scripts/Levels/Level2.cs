using UnityEngine;
using System.Collections;

public class Level2 : BaseLevel
{
	void Start()
	{
		GameObject.FindGameObjectWithTag("HUD").BroadcastMessage("StartLevel");

		lvl = GetComponent<LevelLoader>();
		string map = "" +
			"wwwwwwwwww\n" +
			"w   A    w\n" +
			"w        w\n" +
			"w        w\n" +
			"w   t    w\n" +
			"wwwbbbbwww\n" +
			"w        w\n" +
			"w   t    w\n" +
			"w   P    w\n" +
			"w        w\n" +
			"wwwwwwwwww\n";

		lvl.LoadLevel(map);
		int k = 0;
		lvl.objects[lvl.text] [k++].GetComponentInChildren<TextMesh>().text = "Click & Run!";
		lvl.objects[lvl.text] [k++].GetComponentInChildren<TextMesh>().text = "Level 3";
		for (int i = 0; i < lvl.objects[lvl.text].Count; i++) {
			lvl.objects[lvl.text] [i].gameObject.AddComponent<DestroyOnCollision>();
		}
	}
}

