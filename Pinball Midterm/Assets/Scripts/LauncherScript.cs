﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherScript : MonoBehaviour {

    public float launchForce = 100f;
    public string buttonName = "BallSpring";

    private List<Rigidbody> ballList = new List<Rigidbody>();

    private AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void Update ()
    {
		if(Input.GetButtonDown(buttonName))
        {
            foreach(Rigidbody ball in ballList)
            {
                ball.AddForce(Vector3.forward * launchForce);

                audio.Play();
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Rigidbody>())
        {
            ballList.Add(other.GetComponent<Rigidbody>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ballList.Remove(other.GetComponent<Rigidbody>());
    }


}
