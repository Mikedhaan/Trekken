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
	public GameObject three, two, one, go;
	[SyncVar]
	Quaternion rot;
	// Use this for initialization
	void OnEnable () {
		this.GetComponent<Button> ().interactable = true;
		canvas = GameObject.Find ("Canvas");
		rot = Quaternion.Euler (90, 0, 0);
		//txt = canvas.transform.Find ("Countdown").GetComponent<Text>();
		startG = false;
		//txt.text = "3";
		//countDownGo = canvas.transform.Find ("Countdown").gameObject;
		//countDownGo.SetActive (true);
	}

	// Update is called once per frame
	void Update () {
		//txt.text = currentTxt;
	}
	public void Click()
	{
		this.GetComponent<Button> ().interactable = false;
		StartCoroutine (countDown());

	}
	IEnumerator countDown()
	{
		GameObject threee = (GameObject)Instantiate(three,three.transform.position,rot);
		NetworkServer.Spawn (threee);
		Destroy (threee, 1f);
		yield return new WaitForSeconds (1f);

		GameObject twoo = (GameObject)Instantiate(two,two.transform.position,rot);
		NetworkServer.Spawn (twoo);
		Destroy (twoo, 1f);
		yield return new WaitForSeconds (1f);

		GameObject onee = (GameObject)Instantiate(one,one.transform.position,rot);
		NetworkServer.Spawn (onee);
		Destroy (onee, 1f);
		yield return new WaitForSeconds (1f);

		GameObject goo = (GameObject)Instantiate (go,go.transform.position,rot);
		NetworkServer.Spawn (goo);
		Destroy (threee, 0.5f);
		goo.transform.rotation = rot;
		yield return new WaitForSeconds (0.1f);
		startG = true;
		Health.startCheck = true;
		//countDownGo.SetActive (false);
	}


}
