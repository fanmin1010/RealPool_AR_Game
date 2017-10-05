using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonScript : MonoBehaviour {
	private Color green = Color.green;
	private Color red = Color.red;
	private Color blue = Color.blue;
	private Text tex;
	public int test = 0;
	// Use this for initialization
	void Start () {
		tex = this.transform.GetChild (0).GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		// display (test);
	}
	public void display(int mode){
		if (mode == 0) {
			this.GetComponent<Image> ().color = red;
			tex.text = "Toggle";
		} else if (mode == 1) {
			this.GetComponent<Image> ().color = green;
			tex.text = "Hit!";
		} else if (mode == 2) {
			this.GetComponent<Image> ().color = blue;
			tex.text = "Release";
		}
	}
}
