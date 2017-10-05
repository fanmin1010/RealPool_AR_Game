    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle : MonoBehaviour {
	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {
        		
	}
    public void ToggleMode()
    {
		GameObject testobj = GameObject.Find ("Test(Clone)");
		int temp;
		if (testobj != null) {
			testobj.GetComponent<Networking> ().toggleModeFromClient ();
			temp = GameObject.Find ("Test(Clone)").GetComponent<Networking> ().mode;
			GameObject.Find ("ToggleMode").GetComponent<ButtonScript> ().display (temp);
		}
    }
}
