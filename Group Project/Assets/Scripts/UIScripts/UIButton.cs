using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButton : MonoBehaviour {
	private GameObject buttControl;
	private ButtControl buttScript;
	public GameObject panel;
	private PanelControl panelcontrol;
	private Bounds wandBounds;
	private Bounds thisBounds;

	// Use this for initialization
	void Start () {
		buttControl = this.gameObject.transform.parent.gameObject;
		buttScript = buttControl.GetComponent<ButtControl> ();
		panelcontrol = panel.GetComponent<PanelControl> ();

	}
	
	// Update is called once per frame
	void Update () {
		// do not understand why changed to update not in ontriggerenter
		// that is why the wand has to be put super close to the button - Min
		// button C to switch camera does not work unless it's the biginning
		// changed the size, added pocket scripts to pocket, changed wand image
		wandBounds = GameObject.Find ("WandCube").GetComponent<Renderer> ().bounds;
		thisBounds = GetComponent<Renderer> ().bounds;
		int temp;
		if (thisBounds.Intersects (wandBounds)) {
			print ("intersecting bounds");
			Transform curObj = this.gameObject.transform;
			if (curObj.name == "MatchMode") {
				panelcontrol.initialGame (1);
			} else if (curObj.name == "PracMode") {
				panelcontrol.initialGame (2);
			} else if (curObj.name == "Restart") {
				// add script to switch panels
				Debug.Log("restart button");
				temp = buttScript.mode;
				panelcontrol.initialGame (0);
				panelcontrol.initialGame (temp);
			} else if (curObj.name == "Cancel") {
				// add script to switch panels
				panelcontrol.initialGame (0);
			}

		}
	}
	/*
	void OnTriggerEnter(Collider other) {
		Debug.Log ("collision here");
		Transform touched = other.gameObject.transform;
		Transform curObj = this.gameObject.transform;
		int temp;
		if (touched != null && touched.name == "WandCube") {
			// Debug.Log (curObj.name);
			if (curObj.name == "MatchMode") {
				panelcontrol.initialGame (1);
			} else if (curObj.name == "PracMode") {
				panelcontrol.initialGame (2);
			} else if (curObj.name == "Restart") {
				// add script to switch panels
				temp = buttScript.mode;
				panelcontrol.initialGame (0);
				panelcontrol.initialGame (temp);
			} else if (curObj.name == "Cancel") {
				// add script to switch panels
				panelcontrol.initialGame (0);
			}
		}
	}
	*/

}
