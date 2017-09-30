using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperScript : MonoBehaviour {

    public float force = 100;

    public Vector3 forceDirection = Vector3.forward;
    public Vector3 offset;

    public string buttonName = "LeftPaddle";

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetButton(buttonName))
        {
            rb.AddForceAtPosition(forceDirection.normalized * force, transform.position + offset);
        }
        else
        {
            rb.AddForceAtPosition(forceDirection.normalized * -force, transform.position + offset);
        }
	}
}
