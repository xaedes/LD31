using UnityEngine;
using System.Collections;

public class Level4 : BaseLevel
{
	void Start()
	{
		lvl = GetComponent<LevelLoader>();
		string map = "" +
			"wwwwwwwwww\n" +
			"wA w     w\n" +
			"w  w t   w\n" +
			"w  w  e  w\n" +
			"w  w     w\n" +
			"wbbwwwwwww\n" +
			"w        w\n" +
			"w   e    w\n" +
			"w t t    w\n" +
			"w   P    w\n" +
			"wwwwwwwwww\n";
		
		lvl.LoadLevel(map);
		int k = 0;
		lvl.objects[lvl.text] [k++].GetComponentInChildren<TextMesh>().text = "This\nis an\nenemy";
		lvl.objects[lvl.text] [k++].GetComponentInChildren<TextMesh>().text = "Don't die!";
		lvl.objects[lvl.text] [k++].GetComponentInChildren<TextMesh>().text = "Level 5";
		for (int i = 0; i < lvl.objects[lvl.text].Count; i++) {
			lvl.objects[lvl.text] [i].gameObject.AddComponent<DestroyOnCollision>();
		}

		foreach(GameObject child in GameObject.FindGameObjectsWithTag("Enemy")){
			DestroyOnFlame foo = child.GetComponent<DestroyOnFlame>();
			if( foo != null) {
				Destroy(foo);
			}
		}
	}
}
