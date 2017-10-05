using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ToolBarBehavior : MonoBehaviour, IVirtualButtonEventHandler {

	// Use this for initialization
	void Start () {
		GameObject.Find ("GhostBallButton").GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
		GameObject.Find ("ChangeViewButton").GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}



	public void OnButtonPressed(VirtualButtonAbstractBehaviour vb){
		vb.transform.GetComponentInChildren<Renderer>().material.color = Color.red;
		print (vb.name + " pressed");

		if (vb.name == "ChangeViewButton") {

			GameObject.Find ("CameraManager").SendMessage ("switchCamera");
		} else if (vb.name == "GhostBallButton") {


			GameObject.Find ("WandCube").SendMessage ("shootGhostBall");
		}
	}

	public void OnButtonReleased(VirtualButtonAbstractBehaviour vb){
		vb.transform.GetComponentInChildren<Renderer>().material.color = Color.cyan;
		print (vb.name + " released");
	}
}
