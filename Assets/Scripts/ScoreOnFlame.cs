using UnityEngine;
using System.Collections;

public class ScoreOnFlame : MonoBehaviour
{
	public int scoreChange;
	ScoreManager score;

	void Start()
	{
		score = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManager>();
	}

	void OnFlame()
	{
		GameObject o = GameObject.FindGameObjectWithTag("Score");
		if (o != null) {
			score = o.GetComponent<ScoreManager>();
			if (score != null) {
				score.score += scoreChange;
			}
		}
	}
}
