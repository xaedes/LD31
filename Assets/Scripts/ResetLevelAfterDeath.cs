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
		Grid grid = GameObject.FindGameObjectWithTag("Grid").GetComponent<Grid>();
		grid.SendMessage("RestartLevel",SendMessageOptions.DontRequireReceiver);
	}
}
