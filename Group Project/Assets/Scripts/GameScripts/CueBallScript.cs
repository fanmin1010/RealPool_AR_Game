using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueBallScript : MonoBehaviour {
    int counter = 0;
    bool isMoving = false;
	public GameObject panel;
	public GameObject stickcontainer;
	public GameObject cue_stick;
	Rigidbody rigidb;
	// Use this for initialization
	void Start () {
		rigidb = this.GetComponent<Rigidbody> ();
		cue_stick = stickcontainer.transform.GetChild (1).gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        if (counter>0)
        {
            counter--;
        }
        if (counter == 0)
        {
            GameObject obj = GameObject.Find("Test(Clone)");
            if (obj != null)
            {
                obj.GetComponent<Networking>().resethit();
  
            }
        }
        speedControl ();
		// Debug.Log (rigidb.velocity.magnitude);
		if (isMoving == false && cue_stick.activeSelf != true) {
			// set the stick active and reset its position
			stickcontainer.SendMessage ("resetCueContainer");
			// change interaction mode to 0
			GameObject test = GameObject.Find("Test(Clone)");
			if (test != null)
				test.GetComponent<Networking> ().setInactive ();
		}
	}
	// speed control
	void speedControl(){
		float speed = rigidb.velocity.magnitude;
		if (speed < 0.2 && isMoving) {
            stopBall();
		}
		if (speed >= 0.3) {
			isMoving = true;
		}
	}
    public void stopBall()
    {
        rigidb.velocity = Vector3.zero;
        rigidb.angularVelocity = Vector3.zero;
        // or the following script which is better
        // this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        panel.GetComponent<PanelControl>().swiPlayer();
        stickcontainer.GetComponent<CueContainer>().resetCueContainer();
        isMoving = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
        if (collision.gameObject.name == "Cue")
        {
            GameObject obj = GameObject.Find("Test(Clone)");
            if (obj != null)
            {
                obj.GetComponent<Networking>().sethit();
                counter = 5;

            }

        }
    }
}
