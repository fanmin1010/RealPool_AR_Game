using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayManager : MonoBehaviour {
    string currMessage;
    float timeLeft;
    public Text message;
    bool textExists;
    // Use this for initialization
    void Start()
    {
        timeLeft = 2f;
 //       message = transform.Find("Message").GetComponent<Text>();
        textExists = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        //message.text = timeLeft.ToString();
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            //message.text = "Triggered again!";
            clearText();


        }
    }
    public void updateText(string toWrite, float displayTime)
    {
        clearText();
        timeLeft = displayTime;
        textExists = true;
        message.text = toWrite; 
        //set 

    }
    public void clearText()
    {
        //clear current text
        message.text = "";
        timeLeft = 2f;
        textExists = false;

    }
}





