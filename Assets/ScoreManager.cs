using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {
	public int score;
	public Text text;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Score: " + score;
	}


}
