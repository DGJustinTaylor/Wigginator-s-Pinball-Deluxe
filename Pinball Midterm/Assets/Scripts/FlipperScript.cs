using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperScript : MonoBehaviour {

    public float force = 100;

    public Vector3 forceDirection = Vector3.forward;
    public Vector3 offset;

    public string buttonName = "LeftPaddle";

    private Rigidbody rb;
    private AudioSource audio;

    private bool audioPlayed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();

        audioPlayed = false;
    }

    void Update ()
    {
        if (Input.GetButton(buttonName))
        {
            rb.AddForceAtPosition(forceDirection.normalized * force, transform.position + offset);

            if(!audioPlayed)
            {
                audio.Play();
                audioPlayed = true;
            }
        }
        else
        {
            audioPlayed = false;
            rb.AddForceAtPosition(forceDirection.normalized * -force, transform.position + offset);
        }
	}
}
