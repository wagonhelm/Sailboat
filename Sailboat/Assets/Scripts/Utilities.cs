using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* General static methods for useful calculations */
public class Utilities : MonoBehaviour
{
    // Convert m/s to knots
    static public float msToKnots(float speed)
    {
        return speed * 1.9434f;
    }

    // Calculate hull speed in m/s 
    static public float calcHullSpeed(float length)
    {
        float waterline = length * 0.8f;
        return 1.34f * (float)System.Math.Sqrt(waterline);
    }
}
