using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class NetworkingUI : MonoBehaviour {
	public NetworkManager manager;
	public GameObject button1, button2;
	Button b1,b2;
	// Use this for initialization
	void Start () {
		manager = GetComponent<NetworkManager>();
		b1 = button1.GetComponent<Button> ();
		b2 = button2.GetComponent<Button> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Join()
	{
		b1.onClick.RemoveAllListeners ();
		b2.onClick.RemoveAllListeners ();
		b1.GetComponentInChildren<Text>().text = "Lan";
		b1.onClick.AddListener (() => { JoinLanGame();
		});
		b2.GetComponentInChildren<Text>().text = "Online";
		b2.onClick.AddListener (() => { JoinLanGame();
		});
	}
	public void Host()
	{
		b1.onClick.RemoveAllListeners ();
		b2.onClick.RemoveAllListeners ();
		b1.GetComponentInChildren<Text>().text = "Lan";
		b1.onClick.AddListener (() => { HostLan();
		});
		b2.GetComponentInChildren<Text>().text = "Online";
		b2.onClick.AddListener (() => { Online();
		});
	}
	public void HostLan()
	{
		manager.StartHost ();
	}
	public void DedicatedLan()
	{
		manager.StartServer ();
	}
	public void StopHost()
	{
		manager.StopHost ();
	}
	public void JoinLanGame()
	{
		manager.StartClient ();
	}
	public void Online()
	{
		manager.StartMatchMaker();
	}
}
