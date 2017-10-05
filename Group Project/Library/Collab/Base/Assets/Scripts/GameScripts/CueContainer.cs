using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueContainer : MonoBehaviour {
	private Vector3 initialpos;
	public GameObject cueball;
	public GameObject stick;
	private Vector3 sticklocalpos = new Vector3(0.811f, 0f, 0f);
	private Vector3 initAngles = new Vector3 (0f, 0f, 0f);

	// Use this for initialization
	void Start () {
		initialpos = this.transform.position - cueball.transform.position;
//		sticklocalpos = stick.transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = cueball.transform.position;
	}
	public void resetCueContainer(){
		this.transform.position = cueball.transform.position + initialpos;
		// this.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;
		stick.transform.localPosition = sticklocalpos;
		// stick.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;
		stick.SetActive (true);
		GameObject test = GameObject.Find("Test(Clone)");
		this.transform.eulerAngles = initAngles;
		stick.transform.eulerAngles = initAngles;
		Rigidbody temprigid = stick.GetComponent<Rigidbody> ();
		temprigid.velocity = Vector3.zero;
		temprigid.angularVelocity = Vector3.zero;
		if (test != null)
			test.GetComponent<Networking> ().setInactive ();
        Debug.Log ("jere");
	}
}
