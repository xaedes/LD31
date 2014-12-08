using UnityEngine;
using System.Collections;

public class UnlockWithScore : MonoBehaviour {
	int minimumScore;

	public int MinimumScore {
		get { return minimumScore; }
		set {
			minimumScore = value;
			TextMesh text = GetComponentInChildren<TextMesh>();
			text.text = "Score\n" + "> " + minimumScore;
		}
	}
	ScoreManager score;
	
	void Start () {
		score = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManager>();
	}
	
	void Update () {
		if(score.score >= minimumScore){
			SendMessage("Unlock");
		}
	}
}
