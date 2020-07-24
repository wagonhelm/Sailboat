using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rbTest : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = rb.transform.position - new Vector3(0f, 0f, 6f);
        rb.AddForce(transform.forward * (6f));
    }
}
