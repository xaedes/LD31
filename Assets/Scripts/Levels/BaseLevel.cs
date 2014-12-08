using UnityEngine;
using System.Collections;

public class BaseLevel : MonoBehaviour
{
	public Transform nextLevel;
	protected LevelLoader lvl;
	
	public void NextLevel()
	{
		lvl.DestroyChildren();
		gameObject.tag = "";
		GameObject.Destroy(gameObject);
		Instantiate(nextLevel, transform.position, transform.rotation);
	}
	public void RestartLevel()
	{
		lvl.DestroyChildren();
		SendMessage("Start",SendMessageOptions.DontRequireReceiver);
	}
}
