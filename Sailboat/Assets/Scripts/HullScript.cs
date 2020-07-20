using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HullScript 
    
{
    public float length;
    public float hullSpeed;
    public float waterLineLength;
    public GameObject hull;
    private BoatScript boatscript;

    public HullScript(float length, BoatScript boatscript)
    {
        this.length = length;
        this.boatscript = boatscript;
        this.waterLineLength = getWaterLineLength(length);
        this.hullSpeed = Utilities.msToKnots(Utilities.calcHullSpeed(this.waterLineLength));
        this.hull = createHull(length);
    }

    private GameObject createHull(float length)
    {
        GameObject hull;
        float widthScale = 2.75f;
        float heightScale = 6f;
        hull = GameObject.CreatePrimitive(PrimitiveType.Cube);
        hull.transform.SetParent(this.boatscript.transform);
        hull.name = "Hull";
        hull.transform.localScale = new Vector3(length / widthScale, length / heightScale, length);
        hull.transform.position = new Vector3(0f, length / (heightScale * 2f), 0f);
        hull.AddComponent<Rigidbody>();
        return hull;
    }

    static float getWaterLineLength(float length)
    {
        return length * 0.8f;
    }
}
