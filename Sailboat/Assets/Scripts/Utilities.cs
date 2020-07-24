using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* General static methods for useful calculations */
public class Utilities : MonoBehaviour
    
{
    public enum Tack { forward, starboard, aft, port }

    // Convert m/s to knots
    static public float msToKnots(float speed)
    {
        return speed * 1.9434f;
    }

    // Calculate hull speed in m/s 
    static public float calcHullSpeed(float waterLineLength)
    {
        return 1.34f * (float)System.Math.Sqrt(waterLineLength);
    }

    // Add force from a position with debug line
    static public void addForcePositionDebug(Rigidbody rb, Vector3 force, Vector3 position, float power)
    {
        rb.AddForceAtPosition(force * power, position);
        Debug.DrawLine(position, position + (force * power), Color.red);
    }
}
