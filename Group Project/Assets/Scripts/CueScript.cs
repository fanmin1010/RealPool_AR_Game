using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CueScript : MonoBehaviour {
    private Rigidbody rb;
    public GameObject cue;

    // Use this for initialization
    void Start () {
        
		rb = GetComponent<Rigidbody>();
	
		cue = GameObject.Find("Cue");
        removeCollisions();

	}
	
	// Update is called once per frame
	void resetLocalPositionWithXCoor(float maxX){

		Vector3 localPos = transform.localPosition;
		if (localPos.x > maxX)
			localPos.x = maxX;

		localPos.y = 0f;
		localPos.z = 0f;
		transform.localPosition = localPos;

	}
	void Update () {

		resetLocalPositionWithXCoor (1.2f);

    }
    void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);

        if (collision.gameObject.name == "Cue Ball")
        {
            //GameObject obj = GameObject.Find("Test(Clone)");
            //if (obj != null)
            //{
              //  obj.GetComponent<Networking>().sethit();
            //}
            GameObject ball = collision.gameObject;
            Vector3 direction = Vector3.MoveTowards(ball.transform.position, GameObject.Find("Cue").transform.position, -500);
            Vector3 force = new Vector3(direction.x * Mathf.Abs(GameObject.Find("Cue").GetComponent<Rigidbody>().velocity.x), direction.y * Mathf.Abs(GameObject.Find("Cue").GetComponent<Rigidbody>().velocity.y), direction.z * Mathf.Abs(GameObject.Find("Cue").GetComponent<Rigidbody>().velocity.z));
            ball.GetComponent<Rigidbody>().AddForce( force * 100 );
            GameObject.Find("Cue").SetActive(false);
        }

    }
    public void removeCollisions()
    {

        // set it such that collisions are ignored between cue and everything but cue ball
        Component[] colliders = GameObject.Find("Table").GetComponentsInChildren<Collider>();
        foreach (Collider rbcurr in colliders)
        {
            if (rbcurr.gameObject.name != "Cue Ball")
            {
                Physics.IgnoreCollision(cue.GetComponent<Collider>(), rbcurr);
            }
        }
        //

    }

}

