using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
	private Health health;
	GameObject cracker;
	public GameObject spermPrefab;
	public Transform spermSpawn;

	StartButton startButton;
	public static bool goooooo = true;
	GameObject canvas;
	void Start()
	{
		canvas = GameObject.Find ("Canvas");
		cracker = GameObject.Find ("Cracker");

		startButton = canvas.transform.Find("Start").GetComponentInChildren<StartButton>();
	}

	void Update()
	{
		if (!isLocalPlayer)
			return;

		if(startButton != null)
		if (StartButton.startG && !goooooo)
		{
			//CmdstartGame ();
			goooooo = true;
			canvas.transform.Find("Start").gameObject.SetActive(false);
		}
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			if (goooooo)
			{
				CmdTrekken();
				CmdCum();

			}
		}

		transform.LookAt (cracker.transform);


	}

	public override void OnStartLocalPlayer()
	{
		GetComponent<MeshRenderer>().material.color = Color.red;
	}
	[Command]
	void CmdTrekken()
	{
		int i;
		health = this.GetComponent<Health>();
		float r = Random.Range (0f, 100f);
		if (r > 98f)
			i = 2;
		else
			i = 1;
		this.health.Trekken (i);

	}
	[Command]
	void CmdCum()
	{
		// Create the Bullet from the Bullet Prefab
		var sperm = (GameObject)Instantiate(
			spermPrefab,
			spermSpawn.position,
			spermSpawn.rotation);

		NetworkServer.Spawn(sperm);       
	}

//	[Command]
//	void CmdstartGame()
//	{
//		GameObject[] go = GameObject.FindGameObjectsWithTag ("Player");
//		foreach (GameObject gos in go) {
//			gos.GetComponent<PlayerController> ().goooooo = true;
//
//		}
//	}
}