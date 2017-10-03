using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBallScript : MonoBehaviour {

    private AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);

        audio.Play();
    }



}
