using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class StartButton : NetworkBehaviour {
	// Use this for initialization
	public static bool startG;
	[SyncVar]
	private string currentTxt;
	private Text txt;
	private static GameObject countDownGo;
	GameObject canvas;
	// Use this for initialization
	void OnEnable () {
		canvas = GameObject.Find ("Canvas");
		txt = canvas.transform.Find ("Countdown").GetComponent<Text>();
		startG = false;
		txt.text = "3";
		countDownGo = canvas.transform.Find ("Countdown").gameObject;
		countDownGo.SetActive (true);
	}

	// Update is called once per frame
	void Update () {
		txt.text = currentTxt;
	}
	public void Click()
	{
		this.GetComponent<Button> ().interactable = false;
		StartCoroutine (countDown());

	}
	IEnumerator countDown()
	{
		currentTxt = "3";
		yield return new WaitForSeconds (1f);
		currentTxt = "2";
		yield return new WaitForSeconds (1f);
		currentTxt = "1";
		yield return new WaitForSeconds (1f);
		currentTxt = "GO";
		yield return new WaitForSeconds (0.1f);
		startG = true;
		Health.startCheck = true;
		countDownGo.SetActive (false);
	}
}
