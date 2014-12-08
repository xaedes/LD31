using UnityEngine;
using System.Collections;

public class Level1 : BaseLevel
{
	void Start()
	{
		lvl = GetComponent<LevelLoader>();
		string map = "" +
			"wwwwwwwwww\n" +
			"w   P    w\n" +
			"w   t    w\n" +
			"w        w\n" +
			"w        w\n" +
			"w        w\n" +
			"w        w\n" +
			"w   t    w\n" +
			"w  tAt   w\n" +
			"w   t    w\n" +
			"wwwwwwwwww\n";
		lvl.LoadLevel(map);
		int k = 0;
		lvl.objects[lvl.text] [k++].GetComponentInChildren<TextMesh>().text = "Level 2";
		lvl.objects[lvl.text] [k++].GetComponentInChildren<TextMesh>().text = "W";
		lvl.objects[lvl.text] [k++].GetComponentInChildren<TextMesh>().text = "A";
		lvl.objects[lvl.text] [k++].GetComponentInChildren<TextMesh>().text = "D";
		lvl.objects[lvl.text] [k++].GetComponentInChildren<TextMesh>().text = "S";
		for (int i = 0; i < lvl.objects[lvl.text].Count; i++) {
			lvl.objects[lvl.text] [i].gameObject.AddComponent<DestroyOnCollision>();
		}
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		Destroy(player.GetComponent<PlayerDropBomb>());
	}

}
