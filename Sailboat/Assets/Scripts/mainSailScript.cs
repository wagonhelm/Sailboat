using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class mainSailScript : MonoBehaviour
{
    public enum SailTack { port=0, starboard=1}

    private float maxMainSheet = 90;
    private float minMainSheet = 0;

    bool mainSheetIn;
    bool mainSheetOut;

    public float mainSheet = 0;
    public Text mainSailStatus;

    public GameObject boat;
    private BoatScripts boatScripts;

    string sailTack = "";

    // Start is called before the first frame update
    void Start()
    {
        boatScripts = boat.GetComponent<BoatScripts>();
        mainSailStatus.text = "";

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

        mainSheetIn = Input.GetKey(KeyCode.K);
        mainSheetOut = Input.GetKey(KeyCode.L);

        /* Adjust Sheets */
        if (mainSheetOut && mainSheet < maxMainSheet) 
        {
            mainSheet += 1;
            if (sailTack == "starboard")
            {
                transform.RotateAround(transform.parent.position, transform.parent.up, 1f);
            } 
            else
            {
                transform.RotateAround(transform.parent.position, transform.parent.up, -1f);
            }
        }

        if (mainSheetIn && mainSheet > minMainSheet)
        {
            mainSheet -= 1;
            if (sailTack == "starboard")
            {
                transform.RotateAround(transform.parent.position, transform.parent.up, -1f);
            }
            else
            {
                transform.RotateAround(transform.parent.position, transform.parent.up, 1f);
            }
        }

        if (boatScripts.tack == "port" && sailTack == "starboard" )
        {
            transform.RotateAround(transform.parent.position, transform.parent.up, mainSheet * -2f);
            sailTack = "port";
        }

        if (boatScripts.tack == "starboard" && sailTack == "port")
        {
            transform.RotateAround(transform.parent.position, transform.parent.up, mainSheet * 2f);
            sailTack = "starboard";
        }


        mainSailStatus.text = "Mainsheet: " + mainSheet.ToString() + " " + sailTack + " tack";
        
    }
}
