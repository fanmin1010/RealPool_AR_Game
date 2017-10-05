using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TrackCue : MonoBehaviour {
    public Text textfield ;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 dir = Vector3.zero;
        dir.x = -Input.acceleration.x;
        dir.z = Input.acceleration.z;
        transform.Translate(Input.acceleration.x, 0, -Input.acceleration.z);
        textfield.text = "POWER ="+ Input.acceleration;
        
    }
}
    