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
		lvl.texts [k++].GetComponentInChildren<TextMesh>().text = "Guess you need to kill them...";
		lvl.texts [k++].GetComponentInChildren<TextMesh>().text = "Level 6";
		lvl.texts [k++].GetComponentInChildren<TextMesh>().text = "Unlock this";
		for (int i = 0; i < lvl.texts.Count; i++) {
			lvl.texts [i].gameObject.AddComponent<DestroyOnCollision>();
		}
		
		GameObject[] lcks = GameObject.FindGameObjectsWithTag("Lock");
//		UnlockWithScore uws = lcks[1].AddComponent<UnlockWithScore>();
//		uws.MinimumScore = 20;
		lcks[0].AddComponent<UnlockWithScore>().MinimumScore = 2;
		lcks[1].AddComponent<UnlockWithScore>().MinimumScore = 20;

		GameObject spawn = GameObject.FindGameObjectWithTag("Spawn");
		spawn.GetComponent<SpawnPoint>().spawn = lvl.harmlessEnemy;

//		foreach(GameObject child in GameObject.FindGameObjectsWithTag("Enemy")){
//			EnemyDropBomb foo = child.GetComponent<EnemyDropBomb>();
//			if( foo != null) {
//				Destroy(foo);
//			}
//		}
	}
}
