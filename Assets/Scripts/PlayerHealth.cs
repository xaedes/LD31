using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
	GameObject player;
	Vector2 originalSize;
	Vector2 sizePerHP;
	RectTransform rectTransform;

	// Use this for initialization
	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		rectTransform = GetComponent<RectTransform>();
		originalSize = rectTransform.sizeDelta;
		sizePerHP = originalSize;
		sizePerHP.y = 0;
		originalSize -= sizePerHP;
		rectTransform.sizeDelta = originalSize;
	}
	
	// Update is called once per frame
	void Update()
	{
		if (player == null) {
			player = GameObject.FindGameObjectWithTag("Player");
		}
		if (player != null) {
			rectTransform.sizeDelta = Vector2.Lerp(
			rectTransform.sizeDelta, 
		    originalSize + sizePerHP * player.GetComponent<Health>().hp,
		    2.5f * Time.deltaTime);
		}
	}
}
