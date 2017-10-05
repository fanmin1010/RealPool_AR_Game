using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
    public Camera[] cameras;
    private int currentCameraIndex;
	public Material cueCameraMaterial;
	public Material miniMapMaterial; 
	private string currentCamera = "MiniMap";

    // Use this for initialization
    void Start () {
        //currentCameraIndex = 0;
        //cameras[1].gameObject.SetActiveRecursively(false);
        //cameras[0].gameObject.SetActiveRecursively(false);
        //cameras[2].gameObject.SetActiveRecursively(true);
		GameObject.Find("MiniMapDisplayPort").GetComponent<Renderer>().material = miniMapMaterial;
        
    }



	void switchCamera(){




		if (currentCamera == "MiniMap") {
			currentCamera = "CueBall";
			GameObject.Find ("MiniMapDisplayPort").GetComponent<Renderer> ().material = cueCameraMaterial;
		} else {
			currentCamera = "MiniMap";
			GameObject.Find ("MiniMapDisplayPort").GetComponent<Renderer> ().material = miniMapMaterial;
		}







	}
	
	// Update is called once per frame
	void Update () {
      
		if (Input.GetKeyDown (KeyCode.C)) {
			switchCamera ();

		}
	}
}
