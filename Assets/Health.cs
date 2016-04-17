using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class Health : NetworkBehaviour {
	public GameObject win;
	public GameObject lose;
	int playerAmount;
	public const int maxTrekken = 100;
	[SyncVar]
	public int currentTrekken = 0;
	private Health health;
	public RectTransform rukBar;
	public static bool startCheck = false;
	void Start()
	{
		health = this.GetComponent<Health> ();
	}
	void Update()
	{
		if(currentTrekken <= 100)
			rukBar.sizeDelta = new Vector2(currentTrekken, rukBar.sizeDelta.y);
//		if (!isLocalPlayer)
//		{
//			return;
//		}
		if (startCheck) 
		{
			GameObject[] go = GameObject.FindGameObjectsWithTag ("Player");
			foreach (GameObject gos in go) 
			{
				playerAmount++;
			}
			startCheck = false;
		}

		if (health.currentTrekken >= 100 && health.currentTrekken <= 105)
		{
			if (!isServer)
				health.CmdWin ();
			else
				health.RpcWin ();
		}

		int nietklaarMetTrekken = playerAmount;

		GameObject[] gol = GameObject.FindGameObjectsWithTag ("Player");

		foreach (GameObject go1 in gol) 
		{
			if(go1.GetComponent<Health>().currentTrekken >= 100)
				nietklaarMetTrekken--;
		}
		if(nietklaarMetTrekken == 1)
			foreach (GameObject go1 in gol) 
			{
				if (go1.GetComponent<Health> ().currentTrekken <= 100) {
					if (!isServer)
						go1.GetComponent<Health> ().CmdLose ();
					else
						go1.GetComponent<Health> ().RpcLose ();
					
					nietklaarMetTrekken = 0;
					break;
				}
			}

	}

	public void Trekken(int amount)
	{
		currentTrekken += amount;

	}


	[ClientRpc]
	void RpcWin()
	{
		currentTrekken = 200;
		if (isLocalPlayer)
			Instantiate (win);
	}
	[ClientRpc]
	void RpcLose()
	{
		currentTrekken = 200;
		if(isLocalPlayer)
			Instantiate(lose);
	}
	[Command]
	void CmdWin()
	{
		currentTrekken = 200;
		if (isLocalPlayer)
			Instantiate (win);
	}
	[Command]
	void CmdLose()
	{
		currentTrekken = 200;
		if(isLocalPlayer)
			Instantiate(lose);
	}
}