using UnityEngine;
using System.Collections;

public class Sperm : MonoBehaviour {


	void OnCollisionEnter(Collision coll)
	{
		if (coll.gameObject.tag == "Cracker")
		{
			this.GetComponent<Rigidbody> ().isKinematic = true;
		}
	}
	void Update()
	{
		
	}
}
