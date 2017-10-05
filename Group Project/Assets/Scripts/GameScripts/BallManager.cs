using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour {

	private bool collided;
	// Use this for initialization
	private float radius = 0f;
	private bool selected = false;

	private GameObject surface;
	private GameObject wandCube;
	private Transform originalParent;
	private GameObject displayClone = null;
	private Vector3 initialPosition;
	private Material ballShadowMaterial;
	private bool ifGoDie = false;
	private float dieCountDown = 0f;
	void Start () {
		collided = false;
		radius = GetComponent<SphereCollider> ().radius;
		surface = GameObject.Find ("surface");
		wandCube = GameObject.Find ("WandCube");


		ballShadowMaterial = (Material) Resources.Load("BallShadowMaterial");
		setInitialPosition ();
	}

	void setRadius(float _radius){
		radius = _radius;
	}
	
	// Update is called once per frame
	void Update () {
		if(displayClone) updateDisplayColonePosition ();
		Bounds wandBounds = GameObject.Find ("WandCube").GetComponent<Renderer> ().bounds;
		Bounds thisBounds = GetComponent<Renderer> ().bounds;

		if (!selected) {
			if (thisBounds.Intersects (wandBounds)) {
				this.selected = true;
				wandCube.SendMessage ("selectBall", this.gameObject);
			}
		} else {
			if (!thisBounds.Intersects (wandBounds)) {
				this.selected = false;
			}

		}


		checkGoDie ();
		checkBelowPocket ();
	}


	void checkBelowPocket(){
		float surfaceY = GameObject.Find ("surface").transform.position.y;

		if (transform.position.y < surfaceY -1f) {
			//print ("ball " + this.name + " reseting y");
			resetPosition ();
			zeroSpeed ();
		}


	}
	void checkGoDie(){
		if (ifGoDie) {
			Debug.Log (dieCountDown.ToString ());
			dieCountDown -= Time.deltaTime;
			if (dieCountDown < 0f) {

				Destroy (this.gameObject);
			}
		}
	}

	void updateDisplayColonePosition(){
		Vector3 currentPosition = transform.position;
		currentPosition.y = getGoodYCoordinate ();
		//print (currentPosition.ToString ());
	
		displayClone.transform.position = currentPosition;


	}

	void zeroSpeed(){

		GetComponent<Rigidbody> ().velocity = Vector3.zero;
		GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;
	}
	float getGoodYCoordinate(){
		
		surface = GameObject.Find ("surface");

		return surface.transform.position.y + radius / 2 + 0.001f;
	}
	void initiateYCoordinate(){
		
		zeroSpeed ();
		Vector3 position = transform.position;
		position.y = getGoodYCoordinate ();
		transform.position = position;
	}

	GameObject createDisplayClone(){
		GameObject clone = Instantiate(this.gameObject);
		clone.transform.parent = this.transform.parent;
		clone.GetComponent<Collider> ().enabled = false;
		clone.GetComponent<Rigidbody> ().isKinematic = true;
		clone.transform.localScale = this.transform.localScale;
		Renderer renderer = clone.GetComponent<Renderer> ();
		renderer.material = ballShadowMaterial;
		//Material = (Material) Resources.Load("assets\Materials\BallShadowMaterial");
		//print(Material);
		//Color theColor = renderer.material.color;
		//theColor.a = 0.3f;
		//renderer.material.color = theColor;


		return clone;

	}
	public void enterSelectMode(Transform newParent){
		Bounds wandBounds = GameObject.Find ("WandCube").GetComponent<Renderer> ().bounds;
		Bounds thisBounds = GetComponent<Renderer> ().bounds;


		if (!thisBounds.Intersects (wandBounds)) {
			return;
		}
	
		//print (this.name + " enternig select mode, parent is " + transform.parent.name);
		originalParent = transform.parent;
		transform.parent = newParent;
		this.GetComponent<Collider> ().enabled = false;
		this.GetComponent<Rigidbody> ().isKinematic = true;
		//Destroy (displayClone.GetComponents<Collider> ());
		//Destroy (displayClone.GetComponents<Rigidbody> ());
		displayClone = createDisplayClone();

	}

	public void exitSelectMode(){


		//this.transform.parent = originalParent;
		this.transform.parent = GameObject.Find("Rack").transform;
		//print (this.name + " exiting select mode, parent is " + transform.parent.name);
		this.GetComponent<Collider> ().enabled = true;
		this.GetComponent<Rigidbody> ().isKinematic = false;
		Destroy (displayClone);
		displayClone = null;
		initiateYCoordinate ();

	}

	public void setInitialPosition(){

		initialPosition = transform.localPosition;
	}

	public void resetPosition(){
		transform.localPosition = initialPosition;
	}

	public void setKinematic(){

		GetComponent<Rigidbody> ().isKinematic = true;
	}
	public void unsetKinematic(){

		GetComponent<Rigidbody> ().isKinematic = false;
	}

	public void goDie(float countdown){

		//Debug.Log (this.name + " is going to die after " + countdown.ToString());
		ifGoDie = true;
		dieCountDown = countdown;
	}


}
