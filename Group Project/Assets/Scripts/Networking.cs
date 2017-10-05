using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Networking : NetworkBehaviour
{

    [SyncVar]
    public int hit=0;
    int changemode = 0;

	public int mode = 0;
    private Gyroscope gyro;
    //public GameObject cue;
    [SyncVar]
    Vector3 data = Vector3.zero;
    //Vector3 oldData = Vector3.up;

    [Command]
    public void CmdChangeName(Vector3 newData, int changemode)
    {
        GameObject Cue = GameObject.Find("Cue");
        data = newData;
        if (changemode ==1)
        {
            mode++; 
            mode =mode% 3;
         
        }
        if (mode == 1)
        {
            GameObject parent;
            parent = Cue.transform.parent.gameObject;
            parent.transform.Rotate(0, data.x, 0);
        }else if(mode == 2 )
        {
            //Vector3 direction = Vector3.MoveTowards(Cue.transform.position, GameObject.Find("Cue Ball").transform.position, data.x);

            if (Cue != null && Cue.activeSelf) {
                Cue.transform.position = Vector3.MoveTowards(Cue.transform.position, GameObject.Find("Cue Ball").transform.position, data.x);
            }
        }
    }
    void Start()
    {
    }

    private void Update()
    {
        if (isClient)
        {
            data = new Vector3(Input.acceleration.x, 0, 0);
            GameObject tm = GameObject.Find("ToggleMode");

            //data = gyro.rotationRateUnbiased;
            //data = gyro.attitude.eulerAngles;
            CmdChangeName(data, changemode);
            changemode = 0;
            if(hit == 1)
            {
                Handheld.Vibrate();
                
            }
        }

    }
    public void toggleModeFromClient()
    {
        changemode = 1;
    }
    public void setInactive()
    {
        mode = 0;
    }

    public void sethit()
    {
        hit = 1;
    }
    public void resethit()
    {
        hit = 0;
    }
}