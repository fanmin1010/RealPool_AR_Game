using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Networking2 : NetworkBehaviour
{
    //public GameObject cue;
    [SyncVar]
    Vector3 data = Vector3.up;
    //Vector3 oldData = Vector3.up;

    private void OnGUI()
    {
        //GUI.TextField(new Rect(25, Scre   en.height - 40, 100, 30), "new");
        if (GUI.Button(new Rect(130, Screen.height - 100, 400, 60), "Change"))
        {

            data = Input.acceleration * 5.0F;
            CmdChangeName(data);
        }
    }
    [Command]
    public void CmdChangeName(Vector3 newData)
    {
        data = newData;
        if (GameObject.Find("Temp") == null)
        {
            Debug.Log("Shit");
        }
        else Debug.Log("Found");
        GameObject.Find("Temp").transform.position = GameObject.Find("Temp").transform.position + data;

        Debug.Log("here:" + data);
    }
    private void Update()
    {

    }
}