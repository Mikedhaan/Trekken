using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
	private Health health;
	GameObject cracker;
	public GameObject spermPrefab;
	public Transform spermSpawn;
	GameObject condom;

	void Start()
	{
		condom = GameObject.FindWithTag ("Condom");
		cracker = GameObject.Find ("Cracker");
	}
	void Update()
	{
		if (!isLocalPlayer)
		{
			return;
		}

		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			CmdTrekken ();
			CmdCum ();
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

		// Add velocity to the bullet
		sperm.transform.LookAt(cracker.transform);
		sperm.transform.parent = condom.transform;
		sperm.GetComponent<Rigidbody>().velocity = sperm.transform.forward * 6;
		NetworkServer.Spawn(sperm);       
	}
}