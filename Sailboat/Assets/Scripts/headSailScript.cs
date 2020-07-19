using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class headSailScript : MonoBehaviour
{
    private float maxJibSheet = 90;
    private float minJibSheet = 0;

    bool jibSheetIn;
    bool jibSheetOut;

    public float jibSheet = 0;
    public Text jibSailStatus;

    public GameObject boat;
    private BoatScripts boatScripts;

    string sailTack = "";

    // Start is called before the first frame update
    void Start()
    {
        boatScripts = boat.GetComponent<BoatScripts>();
        jibSailStatus.text = "";
    }

    // Update is called once per frame
    void Update()
    {

        /* Initialize sailTack */
        if (sailTack == "")
        {
            sailTack = boatScripts.tack;
        }

        /* Get Inputs */
        jibSheetIn = Input.GetKey(KeyCode.O);
        jibSheetOut = Input.GetKey(KeyCode.P);

        /* Adjust Sheets */
        if (jibSheetOut && jibSheet < maxJibSheet)
        {
            jibSheet += 1;
            if (sailTack == "starboard")
            {
                transform.RotateAround(transform.parent.position, transform.parent.up, 1f);
            }
            else
            {
                transform.RotateAround(transform.parent.position, transform.parent.up, -1f);
            }
        }

        if (jibSheetIn && jibSheet > minJibSheet)
        {
            jibSheet -= 1;
            if (sailTack == "starboard")
            {
                transform.RotateAround(transform.parent.position, transform.parent.up, -1f);
            }
            else
            {
                transform.RotateAround(transform.parent.position, transform.parent.up, 1f);
            }
        }

        if (boatScripts.tack == "port" && sailTack == "starboard")
        {
            transform.RotateAround(transform.parent.position, transform.parent.up, jibSheet * -2f);
            sailTack = "port";
        }

        if (boatScripts.tack == "starboard" && sailTack == "port")
        {
            transform.RotateAround(transform.parent.position, transform.parent.up, jibSheet * 2f);
            sailTack = "starboard";
        }


        jibSailStatus.text = "jibsheet: " + jibSheet.ToString() + " " + sailTack + " tack";

    }
}
