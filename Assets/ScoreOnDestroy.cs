﻿using UnityEngine;
using System.Collections;

public class ScoreOnDestroy : MonoBehaviour
{
	public int scoreChange;
	ScoreManager score;

	void Start()
	{
		score = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManager>();
	}
	void OnDestroy()
	{
		score.score += scoreChange;
	}
}
