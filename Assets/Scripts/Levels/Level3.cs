﻿using UnityEngine;
using System.Collections;

public class Level3 : BaseLevel
{
	void Start()
	{
		GameObject.FindGameObjectWithTag("HUD").BroadcastMessage("StartLevel");
		
		lvl = GetComponent<LevelLoader>();
		string map = "" +
			"wwwwwwwwww\n" +
			"wPtb bwwww\n" +
			"wwwwbbwwww\n" +
			"wwww  wwww\n" +
			"wwwwbbwwww\n" +
			"wwww  wwww\n" +
			"wwwwbbwwww\n" +
			"wwwwt wwww\n" +
			"wwwwAwwwww\n" +
			"wwwwwwwwww\n" +
			"wwwwwwwwww\n";
		
		lvl.LoadLevel(map);
		int k = 0;
		lvl.objects[lvl.text] [k++].GetComponentInChildren<TextMesh>().text = "Level 4";
		lvl.objects[lvl.text] [k++].GetComponentInChildren<TextMesh>().text = "This\nway";
		for (int i = 0; i < lvl.objects[lvl.text].Count; i++) {
			lvl.objects[lvl.text] [i].gameObject.AddComponent<DestroyOnCollision>();
		}
	}
}
