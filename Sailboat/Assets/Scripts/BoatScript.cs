using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BoatScript : MonoBehaviour
{
    /* Public Variables */
    public float boatLength = 10f;
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
    private Rigidbody rb;
   
    /* Boat Components */
    public HullScript hull;
    public GameObject ocean;
    public Vector3 massCenter;
    public Vector3 direction;
    public GameObject frontRight;
    public GameObject frontLeft;
    public GameObject backRight;
    public GameObject backLeft;
    public float force = 10;
    public float velocity;

    void Awake()
    {
        hull = new HullScript(boatLength, this);
        this.transform.localScale = this.hull.boatDim;
        // Adjust ocean height to sit below boat
        ocean.transform.position = new Vector3(0f, -this.hull.boatDim.y/2f, 0f);

        rb = GetComponent<Rigidbody>();

        // Create center of mass below boat
        //rb.centerOfMass = this.rb.transform.position + new Vector3(0, -hull.boatDim.y*1.1f, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        massCenter = rb.centerOfMass;
        direction = Vector3.Cross(-frontRight.transform.up, frontRight.transform.forward);
        Utilities.addForcePositionDebug(rb, direction, frontRight.transform.position, force);
        velocity = rb.velocity.magnitude;


    }

    private void OnDrawGizmos()
    {
        // Visualize Center Of Mass
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position + transform.rotation * massCenter, transform.localScale.y/2f);
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
        //Debug.Log("Boat: Set Tiller To: " + tillerInput.ToString());
        tillerPos = tillerInput;
    }

    //public Vector3 getPositionOnBoatEdge(int degrees)
    //{

    //}


}
