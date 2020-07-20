using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject boat;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - boat.transform.position;
    }

    void LateUpdate()
    {
        transform.position = boat.transform.position + offset;
    }
}
