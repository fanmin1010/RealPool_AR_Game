using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class PocketScript : MonoBehaviour {
	private GameObject par;
	// Use this for initialization
	void Start () {
		par = this.transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
        Debug.Log("collided");
		Transform touched = other.gameObject.transform;
		Transform curObj = this.gameObject.transform;
		string bname;
		int tempnum;
		if (touched != null)
			bname = touched.name;
		else
			return;

        Debug.Log("before action");
		if (bname == "Cue Ball") {
			par.SendMessage ("pocketBall", value: 0);
		} else if (Int32.TryParse (bname, out tempnum)) {
			par.SendMessage ("pocketBall", value: tempnum);
			if(tempnum != 8)
				Destroy(other.gameObject, 3.0f);
		} else {
			Debug.Log ("Collision is not a ball");
		}
	}
}
