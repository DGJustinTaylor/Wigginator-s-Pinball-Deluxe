using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherScript : MonoBehaviour {

    public float launchForce = 100f;
    public string buttonName = "BallSpring";

    private List<Rigidbody> ballList = new List<Rigidbody>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetButtonDown(buttonName))
        {
            foreach(Rigidbody ball in ballList)
            {
                ball.AddForce(Vector3.forward * launchForce);
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
