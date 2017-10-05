using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TableScript : MonoBehaviour {
	public GameObject cue_ball;
	public GameObject ball_8;
	public Vector3 cue_pos;
	public Vector3 pos_8;
	public GameObject panel;
	public GameObject resultPanel;
	public Text desc;
	// Use this for initialization
	void Start () {
		cue_pos = cue_ball.transform.position;
		pos_8 = ball_8.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void pocketBall(int number){
		int asc, bsc;
		if(number == 0)
			StartCoroutine(cue_reset(number));
		else if(number == 8){
			asc = panel.GetComponent<PanelControl> ().ascore;
			bsc = panel.GetComponent<PanelControl> ().bscore;
			if (asc == 7) {
				showPanel (1);
				desc.text = "A";
				Debug.Log ("Player A win!");
			} else if (bsc == 7) {
				showPanel (1);
				desc.text = "B";
				Debug.Log ("Player B win!");
			} else{
				StartCoroutine(cue_reset(number));
			}
		} else {
			if (panel != null && panel.activeSelf != false)
				panel.SendMessage ("scoreUpdate", value: number); 
		}
	}
	IEnumerator cue_reset(int num) {
		Rigidbody rb;
		GameObject ball = cue_ball;
		Vector3 pos = cue_pos;
		if (num == 8) {
			ball = ball_8;
			pos = pos_8;
		}
		yield return new WaitForSeconds(2);
		ball.transform.position = pos;
		rb = ball.GetComponent<Rigidbody> ();
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
	}
	void showPanel(int num){
		panel.SetActive (num == 0);
		resultPanel.SetActive (num == 1);
	}
}
