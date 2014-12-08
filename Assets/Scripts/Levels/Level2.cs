﻿using UnityEngine;
using System.Collections;

public class Level2 : MonoBehaviour
{
	public Transform nextLevel;
	LevelLoader lvl;
	
	// Use this for initialization
	void Start()
	{
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
		lvl.texts [k++].GetComponentInChildren<TextMesh>().text = "Click & Run!";
		lvl.texts [k++].GetComponentInChildren<TextMesh>().text = "Level 3";
		for (int i = 0; i < lvl.texts.Count; i++) {
			lvl.texts [i].gameObject.AddComponent<DestroyOnCollision>();
		}
	}

	public void NextLevel()
	{
		lvl.DestroyChildren();
		gameObject.tag = "";
		GameObject.Destroy(gameObject);
		Instantiate(nextLevel, transform.position, transform.rotation);
	}

}
