using UnityEngine;
using System.Collections;

public class ResetLevelAfterDeath : MonoBehaviour
{
	public float wait;
	
	void OnDeath()
	{
		Invoke("restart", wait);
	
	}

	void restart()
	{
		Application.LoadLevel(Application.loadedLevel);
	}
}
