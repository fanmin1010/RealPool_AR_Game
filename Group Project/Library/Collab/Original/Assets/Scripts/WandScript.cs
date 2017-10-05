using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class WandScript : MonoBehaviour, IVirtualButtonEventHandler{
    public GameObject wandcube;
    public GameObject Cue;
	public GameObject wandButton;
    private Transform oldWandCubeTransform;
    private Vector3 oldpos;
    public Material ghostballMat;
    float timeLeft = 5.0f;
    public bool movemode; // true is rotate, false is hit
	public GameObject parent;

	GameObject selectedBall;
	bool selectedMode = false;
	// Use this for initialization


	void Start () {
		parent = Cue.transform.parent.gameObject;
        movemode = true;
//        wandcube = GameObject.Find("Wand");
//        Cue = GameObject.Find("Cue");
        oldWandCubeTransform = wandcube.transform;
        oldpos = wandcube.transform.position;

        GameObject cushions = GameObject.Find("cushions");
        if (cushions != null)
        {

            GameObject table = GameObject.Find("Table");
            Component[] rbs = table.GetComponentsInChildren(typeof(Rigidbody));
            foreach (Rigidbody rb in rbs)
            {
                //Physics.IgnoreCollision(rb.gameObject.GetComponent<Collider>(), cushions.GetComponent<Collider>());
            }
        }

//		wandButton = GameObject.Find ("WandButton");
		wandButton.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);

    }


	void shootGhostBall(){

		GameObject ghostball = null;
		ghostball = Instantiate(GameObject.Find("Cue Ball"), GameObject.Find("BallContainer").transform);
		ghostball.SendMessage ("goDie", 1f);
		ghostball.transform.position = new Vector3(ghostball.transform.position.x, ghostball.transform.position.y, ghostball.transform.position.z);
		ghostball.GetComponent<Renderer>().material = ghostballMat;
		//ghostball.transform.SetParent(GameObject.Find("BallContainer").transform);
		Vector3 direction = ghostball.transform.position-  Cue.transform.position;
		Physics.IgnoreCollision(GameObject.Find("Cue Ball").gameObject.GetComponent<Collider>(), ghostball.GetComponent<Collider>());
		Physics.IgnoreCollision(GameObject.Find("Cue").gameObject.GetComponent<Collider>(), ghostball.GetComponent<Collider>());
		print("hello");
		GameObject rack = GameObject.Find("Rack");

		foreach (Transform child in rack.transform)
		{
			Physics.IgnoreCollision(ghostball.GetComponent<Collider>(), child.gameObject.GetComponent<Collider>());
		}
		ghostball.name = "GhostBall";




		//ghostball.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
		ghostball.GetComponent<Rigidbody>().AddForce(direction *  1000);
	}
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.G))// Ghostball
        {
			shootGhostBall ();


        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            movemode = !movemode;
            Cue.GetComponent<Rigidbody>().freezeRotation = !Cue.GetComponent<Rigidbody>().freezeRotation;
            
        }
        float change = wandcube.transform.position.y - oldpos.y;
       
    
        if (movemode)
        {
            rotateObject(change);

        }
        else
        {
            moveCue(change);
        }
        oldWandCubeTransform = wandcube.transform;
        oldpos = wandcube.transform.position;
    }


    private void rotateObject(float change)
    {  
        parent.transform.Rotate(0, change * (float)30 ,0 );
    }
    private void moveCue(float change)
    {
        Vector3 direction = Vector3.MoveTowards(Cue.transform.position, GameObject.Find("Cue Ball").transform.position, change);
        Cue.transform.position =  Vector3.MoveTowards(Cue.transform.position, GameObject.Find("Cue Ball").transform.position , change);
    }
   


	public void selectBall(GameObject ball){
		if(!selectedMode)selectedBall = ball;
		//print ("selecting " + ball.name);
	}
		

	public void trySelectDeselect(){

		if (selectedMode && selectedBall != null) {
			selectedMode = false;
			selectedBall.SendMessage ("exitSelectMode");
		} else if (!selectedMode && selectedBall != null) {
			selectedMode = true;
			selectedBall.SendMessage ("enterSelectMode", this.transform);
		}


	}

	public void OnButtonPressed(VirtualButtonAbstractBehaviour vb){
		//print ("pressed");
		vb.transform.GetComponentInChildren<Renderer>().material.color = Color.red;
		if (selectedBall != null) {
			selectedMode = true;
			selectedBall.SendMessage ("enterSelectMode", this.transform);
		}
	}

	public void OnButtonReleased(VirtualButtonAbstractBehaviour vb){

		//print ("released");
		vb.transform.GetComponentInChildren<Renderer>().material.color = Color.cyan;
		if (selectedBall != null) {
			selectedBall.SendMessage ("exitSelectMode");
			selectedMode = false;
		}
	}
}
