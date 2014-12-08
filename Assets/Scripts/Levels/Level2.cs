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
				"wwwwwwwwww\n"+
				"w      P w\n"+
				"w        w\n"+
				"w        w\n"+
				"w        w\n"+
				"w        w\n"+
				"w        w\n"+
				"w        w\n"+
				"w    A   w\n"+
				"w        w\n"+
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

