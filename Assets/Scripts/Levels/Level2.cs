using UnityEngine;
using System.Collections;

public class Level2 : MonoBehaviour 
{
	public Transform nextLevel;
	LevelLoader lvl;
	
	// Use this for initialization
	void Start()
	{
		lvl = GetComponent<LevelLoader>();
		string map = ""+
				"wwwwwwwwww\n" +
				"wP    bbsw\n" +
				"wwwwwww bw\n" +
				"w       bw\n" +
				"w        w\n" +
				"w       bw\n" +
				"wb bb   bw\n" +
				"w  Ab    w\n" +
				"w  bb    w\n" +
				"wP   b   w\n" +
				"wwwwwwwwww\n";

		lvl.LoadLevel(map);
		
	}

	public void NextLevel() 
	{
		lvl.DestroyChildren();
		gameObject.tag = "";
		GameObject.Destroy(gameObject);
		Instantiate(nextLevel, transform.position, transform.rotation);
	}

}

