using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class HasGridValues : MonoBehaviour
{
	Dictionary<string, Dictionary<int, float>> values;
	
	void Start()
	{
		values = new Dictionary<string, Dictionary<int, float>>();
	
	}

	public void Set(string key, Vector3 pos, float value)
	{
		Set(key, Grid.index(pos), value);
	}
	
	public float Get(string key, Vector3 pos, float defaultValue)
	{
		return Get(key, Grid.index(pos), defaultValue);
	}

	public void Set(string key, int idx, float value)
	{
		if (!values.ContainsKey(key)) {
			values.Add(key, new Dictionary<int, float>());
		}
		values [key] [idx] = value;
	}

	public float Get(string key, int idx, float defaultValue)
	{
		if (!values.ContainsKey(key) || !values [key].ContainsKey(idx)) {
			return defaultValue;
		}
		return values [key] [idx];
	}

	public float this [string key, int idx] {
		get {
			return Get(key, idx, 0);
		}
		set {
			Set(key, idx, value);
		}
	}

	public List<int> Indices(string key)
	{
		if (!values.ContainsKey(key))
			return new List<int>();
		else
			return values [key].Keys.ToList();
	}

	public Dictionary<int, float> this [string key] {
		get {
			return values [key];
		}
		set {
			Dictionary<int, float> copy = new Dictionary<int, float>(value);
			values [key] = copy;
		}
	}
}
