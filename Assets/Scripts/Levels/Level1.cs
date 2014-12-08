using UnityEngine;
using System.Collections;

public class Level1 : MonoBehaviour
{
	public Transform nextLevel;
	LevelLoader lvl;

	// Use this for initialization
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
		lvl.texts[k++].GetComponentInChildren<TextMesh>().text = "Level 2";
		lvl.texts[k++].GetComponentInChildren<TextMesh>().text = "W";
		lvl.texts[k++].GetComponentInChildren<TextMesh>().text = "A";
		lvl.texts[k++].GetComponentInChildren<TextMesh>().text = "D";
		lvl.texts[k++].GetComponentInChildren<TextMesh>().text = "S";
		for(int i = 0; i < lvl.texts.Count; i++) {
			lvl.texts[i].gameObject.AddComponent<DestroyOnCollision>();
		}
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		Destroy(player.GetComponent<PlayerDropBomb>());
	}
	public void NextLevel() 
	{
		lvl.DestroyChildren();
		gameObject.tag = "";
		GameObject.Destroy(gameObject);
		Instantiate(nextLevel, transform.position, transform.rotation);
	}

}
