using UnityEngine;
using System.Collections;

public class Level3 : MonoBehaviour
{
	public Transform nextLevel;
	LevelLoader lvl;
	
	// Use this for initialization
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
	
	public void NextLevel()
	{
		lvl.DestroyChildren();
		gameObject.tag = "";
		GameObject.Destroy(gameObject);
		Instantiate(nextLevel, transform.position, transform.rotation);
	}
	public void RestartLevel()
	{
		lvl.DestroyChildren();
		Start();
	}
}
