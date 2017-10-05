using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PanelControl : MonoBehaviour {
	// current player 0-A, 1-B
	public int curPlayer = 1;
	public int ascore = 0;
	public int bscore = 0;
	public GameObject buttcont;
	private ButtControl buttscript;
	private Text curA;
	private Text curB;
	public Text scr_a;
	public Text scr_b;
	public Image scoreboard;
	public GameObject poolTable;
	public GameObject rack;
	public GameObject cue_ball;
	public GameObject cue_stick;
	private Vector3 tableposinit;
	private Vector3 rackposinit;
	private Vector3 cueballinitpos;
	private Vector3 cueinitpos;

	// Use this for initialization
	void Start () {
		buttscript = buttcont.GetComponent<ButtControl> ();
		Text[] temparr = this.GetComponentsInChildren<Text> (true);
		curA = temparr [0];
		curB = temparr [1];
		setInitialPos (0);
	}

	void broadcastAllBalls(string method){
		
		rack.BroadcastMessage (method);
		cue_ball.SendMessage (method);
	}
	// Update is called once per frame
	void Update () {
		curA.gameObject.SetActive (curPlayer == 0);
		curB.gameObject.SetActive (curPlayer == 1);
		scr_a.text = ascore.ToString ();
		scr_b.text = bscore.ToString ();
	}
	// start the game with mode signal 0-main 1-match 2-practice
	public void initialGame(int mode){
		broadcastAllBalls ("initiateYCoordinate");

		switch (mode)
		{
		case 0:
			retMain ();
			break;
		case 1:
			startMatch ();
			break;
		case 2:
			startPract ();
			break;
		}
	}
	void retMain(){
		buttscript.mode = 0;
		// this method is not complete
		setInitialPos(1);

	}
	void startMatch(){
		buttscript.mode = 1;
		poolTable.SetActive (true);
		curPlayer = 1;
		ascore = 0;
		bscore = 0;
		scoreboard.gameObject.SetActive (true);
		rack.SetActive (true);
		Transform[] allballs = rack.GetComponentsInChildren<Transform> (true);
		foreach (Transform ball in allballs) {
			ball.gameObject.SetActive (true);
		}
		rack.BroadcastMessage ("resetPosition");
		cue_ball.SendMessage ("resetPosition");
	}
	void startPract(){
		buttscript.mode = 2;
		poolTable.SetActive (true);
		curA.gameObject.SetActive (false);
		curB.gameObject.SetActive (false);
		scoreboard.gameObject.SetActive (false);
		rack.SetActive (true);
		Transform[] allballs = rack.GetComponentsInChildren<Transform> (true);
		foreach (Transform ball in allballs) {
			ball.gameObject.SetActive (false);
		}
		GameObject eight = rack.transform.Find ("8").gameObject;
		eight.SetActive (true);
		rack.SetActive (true);
		cue_ball.SendMessage ("resetPosition");
		eight.SendMessage ("resetPosition");
	}
	// update score by 1 each time, player A - 1-7; B - 9-15
	void scoreUpdate(int ballnum){
		if (ballnum >= 1 && ballnum <= 7) {
			ascore++;
		} else if (ballnum >= 9 && ballnum <= 15) {
			bscore++;
		}
	}
	public void swiPlayer(){
		curPlayer = 1 - curPlayer;
	}
	void setInitialPos(int signal){
		// signal = 0 initialize all pos vectors
		// signal = 1 reset all positions
		Debug.Log("in setinitialpos function");
		if (signal == 0) {
			tableposinit = poolTable.transform.position;
			rackposinit = rack.transform.position;
			cueballinitpos = cue_ball.transform.position;
			cueinitpos = cue_stick.transform.position;
		} else if (signal == 1) {
			poolTable.transform.position = tableposinit;
			rack.transform.position = rackposinit;
			cue_ball.transform.position = cueballinitpos;
			cue_stick.transform.position = cueinitpos;
		}
	}
}
