using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class mainSailScript : MonoBehaviour
{


    private float maxMainSheet = 90;
    private float minMainSheet = 0;

    bool mainSheetIn;
    bool mainSheetOut;

    public float mainSheet = 0;
    public Text mainSailStatus;


    // Start is called before the first frame update
    void Start()
    {
        mainSailStatus.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        /* Get Inputs */

        mainSheetIn = Input.GetKey(KeyCode.K);
        mainSheetOut = Input.GetKey(KeyCode.L);

        /* Adjust Sheets */
        if (mainSheetOut && mainSheet < maxMainSheet) 
        {
            mainSheet += 1;
            transform.RotateAround(transform.parent.position, transform.parent.up, 1f);
        }
        if (mainSheetIn && mainSheet > minMainSheet)
        {
            mainSheet -= 1;
            transform.RotateAround(transform.parent.position, transform.parent.up, -1f);
        }

            mainSailStatus.text = "Mainsail: " + mainSheet.ToString();
        
    }
}
