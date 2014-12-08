using UnityEngine;
using System.Collections;

public class Level5 : BaseLevel
{
	void Start()
	{
		lvl = GetComponent<LevelLoader>();
		string map = "" +
			"wwwwwwwwww\n" +
			"w  t  LtPw\n" +
			"wbbwwwwwww\n" +
			"w     h sw\n" +
			"wbbbbbbbbw\n" +
			"w h    h w\n" +
			"wwwwLwwwww\n" +
			"w   t  h w\n" +
			"wbbbbbbbbw\n" +
			"w   A    w\n" +
			"wwwwwwwwww\n";
		
		lvl.LoadLevel(map);
		int k = 0;
		lvl.objects[lvl.text] [k++].GetComponentInChildren<TextMesh>().text = "Guess you need to kill them...";
		lvl.objects[lvl.text] [k++].GetComponentInChildren<TextMesh>().text = "Level 6";
		lvl.objects[lvl.text] [k++].GetComponentInChildren<TextMesh>().text = "Unlock this";
		for (int i = 0; i < lvl.objects[lvl.text].Count; i++) {
			lvl.objects[lvl.text] [i].gameObject.AddComponent<DestroyOnCollision>();
		}
		
		lvl.objects[lvl.lck][0].AddComponent<UnlockWithScore>().MinimumScore = 15;
		lvl.objects[lvl.lck][1].AddComponent<UnlockWithScore>().MinimumScore = 2;

		lvl.objects[lvl.spawn][0].GetComponent<SpawnPoint>().spawn = lvl.harmlessEnemy;

	}
}
