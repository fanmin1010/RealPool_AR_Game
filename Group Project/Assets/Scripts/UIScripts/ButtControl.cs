using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtControl : MonoBehaviour {
	// playing mode: 1-match mode; 2-practice mode
	public int mode = 0;
	public GameObject startMatch;
	public GameObject startPrac;
	public GameObject restart;
	public GameObject exit;
	public GameObject uipanel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		startMatch.SetActive (mode == 0);
		startPrac.SetActive (mode == 0);
		restart.SetActive (mode != 0);
		exit.SetActive (mode != 0);
		uipanel.SetActive (mode == 1);
	}
}
