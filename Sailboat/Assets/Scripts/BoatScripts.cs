using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class BoatScripts : MonoBehaviour
{

    public enum Tack : short { forward, port, astern, starboard };

    /* Public Variable */
    public float tiller;
    public float turnSpeed = 2;
    public const int windDir = 0;
    public const int windSpeed = 15;
    public float forwardForce = 15;
    public float speed;
    public Text status;
    public string tack;
    private float maxForwardForce = 15;



    /* Private Variables */
    private Rigidbody rb;
    private Vector3 turnVelocity;
    private Vector3 lastPosition;


    void Start()
    {

        rb = GetComponent<Rigidbody>();
        lastPosition = transform.position;
        status.text = "";
    }

    void FixedUpdate()
    {
        /* Get Inputs */
        tiller = Input.GetAxis("Horizontal");

        /* Get Tack */
        tack = getTack();

        /* Calculate speed using delta position */
        speed = (transform.position - lastPosition).magnitude;
        lastPosition = transform.position;

        /* Hacky Speed Limiter */
        if (speed > 1)
        {
            forwardForce -= 1;
        }
        else { forwardForce = maxForwardForce; }

        /* Perform turn and adjust speed */
        turnVelocity = new Vector3(0, tiller * speed * turnSpeed, 0);
        Quaternion deltaRoation = Quaternion.Euler(turnVelocity * forwardForce * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRoation);

        /* Apply forward force */
        if (forwardForce > 0)
        {
            /* If force is applied to tiller, slow down boat */
            rb.AddForce(transform.forward * (forwardForce - (turnSpeed * tiller)));
        } else
        {
            rb.AddForce(transform.forward * (forwardForce + (turnSpeed * tiller)));
        }

        /* Update Status Text */
        status.text = "Tiller: " + tiller.ToString() + "\n" +
            "Wind Direction: " + windDir.ToString() + "+\n" +
            "Wind Speed: " + windSpeed.ToString() + "+\n" +
            "Tack: " + tack.ToString() + "+\n" +
            "Boat Speed: " + speed.ToString();
    }

    string getTack()
    /* forward is considered 30 degrees off bow, astern is considered 5 degrees off stern */
    {
        int forwardCut = 5;
        int asternCut = 5;

        float angle = transform.rotation.eulerAngles.y;
        if ((angle > 360 - forwardCut) || (angle < forwardCut))
        {
            return Tack.forward.ToString();
        }
        if ((angle > forwardCut) && (angle < 180 - asternCut))
        {
            return Tack.port.ToString();
        }
        if ((angle > 180 - asternCut) && (angle < 180 + asternCut))
        {
            return Tack.astern.ToString();
        }
        return Tack.starboard.ToString();
    }
}