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

    // Start is called before the first frame update
    void Start()
    {
        jibSailStatus.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        /* Get Inputs */
        jibSheetIn = Input.GetKey(KeyCode.O);
        jibSheetOut = Input.GetKey(KeyCode.P);

        /* Adjust Sheets */
        if (jibSheetOut && jibSheet < maxJibSheet)
        {
            jibSheet += 1;
            transform.RotateAround(transform.parent.position, transform.parent.up, 1f);
        }
        if (jibSheetIn && jibSheet > minJibSheet)
        {
            jibSheet -= 1;
            transform.RotateAround(transform.parent.position, transform.parent.up, -1f);
        }

        jibSailStatus.text = "Headsail: " + jibSheet.ToString();
    }
}
