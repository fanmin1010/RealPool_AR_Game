using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{

    Vector3 position;
    Vector3 originalPos;
    // Use this for initialization
    void Start()
    {
        position = transform.position;
        originalPos = position;



    }

    // Update is called once per frame
    void Update()
    {
        



        position = transform.position;
        if (position.y < -5)
        {
            if (gameObject.tag == "Solids")
            {
                print("Solid scores");
            }
            else if (gameObject.tag == "Stripes")
            {
                print("Stripes scores");
            }
            else if (gameObject.tag == "Black")
            {
                print("8 ball pocketed");
            }
            else if (gameObject.tag == "White")
            {
                print("White ball pocketed");
            }
            originalPos = transform.position;
        }

    }
}