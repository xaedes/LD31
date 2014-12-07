using UnityEngine;
using System.Collections;

public class DestroyOnFlame : MonoBehaviour
{

	public void OnFlame(Object flame)
	{
		Destroy(this.gameObject);
	}
}
