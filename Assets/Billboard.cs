using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour {
	GameObject lookat;
	void Start()
	{
		lookat = GameObject.Find ("Spawn3");
	}
	void Update () {
		transform.LookAt(lookat.transform);
	}
}