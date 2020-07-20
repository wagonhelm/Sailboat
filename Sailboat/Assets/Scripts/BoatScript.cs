using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BoatScript : MonoBehaviour
{
    /* Public Variables */
    public float boatLength = 6f;
    [Range(-1f, 1f)] 
    public float tillerPos;
    [Range(0, 90)]
    public int mainSheet = 0;
    [Range(0, 90)]
    public int jibSheet = 0;
    public Utilities.Tack tack;

    /* Private Variables */
    private int mainSheetMin = 0;
    private int mainSheetMax = 90;
    private int jibSheetMin = 0;
    private int jibSheetMax = 90;

    void Start()
    {
        // Create hull with reference to BoatClass parent class
        HullScript hull = new HullScript(boatLength, this);
        Debug.Log("Hull created with length: " + hull.length.ToString()  + "m water line length: " + hull.waterLineLength + "m  and max hull speed: " + hull.hullSpeed.ToString() + " knots");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     
    /* Public Methods ========================================================== */
    public void mainSheetIn()
    {
        Debug.Log("Boat: Mainsheet In");
        
        if (mainSheet > mainSheetMin) mainSheet -= 1;
    }

    public void mainSheetOut()
    {
        Debug.Log("Boat: Mainsheet Out");
        if (mainSheet < mainSheetMax) mainSheet += 1;
    }

    public void jibSheetIn()
    {
        Debug.Log("Boat: Jibsheet In");
        if (jibSheet > jibSheetMin) jibSheet -= 1;
    }

    public void jibSheetOut()
    {
        Debug.Log("Boat: Jibsheet Out");
        if (jibSheet < jibSheetMax) jibSheet += 1;
    }

    public void setTiller(float tillerInput)
    {
        Debug.Log("Boat: Set Tiller To: " + tillerInput.ToString());
        tillerPos = tillerInput;
    }

}
