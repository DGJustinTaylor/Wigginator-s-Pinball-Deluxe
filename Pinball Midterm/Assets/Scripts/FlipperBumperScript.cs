using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperBumperScript : MonoBehaviour {

    public float force = 100f;

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();

        if(rb != null)
        {
            rb.AddForce(transform.forward * force);
            GameDataScript.score += 5000;
        }
    }
}
