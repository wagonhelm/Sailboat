using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HullScript
    
{
    public float length;
    public float hullSpeed;
    public float waterLineLength;
    public BoatScript boatScript;
    public Vector3 boatDim;

    public HullScript(float length, BoatScript boat) {
        this.length = boat.boatLength;
        this.waterLineLength = getWaterLineLength(length);
        this.hullSpeed = Utilities.msToKnots(Utilities.calcHullSpeed(waterLineLength));
        Debug.Log("Hull created:\nlength: " + this.length.ToString() + "m waterline: " + this.waterLineLength + "m  and hullspeed: " + this.hullSpeed.ToString() + " knots");
        this.boatDim = Vector3.Scale(new Vector3(length/10, length/10, length/10), boat.transform.localScale);
        Debug.Log("Boat dimensions: " + boatDim.ToString());
    }

    static float getWaterLineLength(float length)
    {
        return length * 0.8f;
    }
}
