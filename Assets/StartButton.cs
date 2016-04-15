using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {
	public bool start;
	// Use this for initialization
	void Start () {
		start = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Click()
	{
		start = true;
	}
}
