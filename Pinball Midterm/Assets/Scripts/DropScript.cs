﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropScript : MonoBehaviour
{

    public float dropDist = 1f;
    public float resetDelay = 0.5f;

    public int chainID = 0;
    public int singleScoreVal = 2000;
    public int allScoreVal = 8000;

    private AudioSource audio;

    public static List<DropScript> drops = new List<DropScript>();

    public bool isDropped = false;

    private void Start()
    {
        drops.Add(this);

        audio = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter()
    {
        if (!isDropped)
        {
            transform.position += Vector3.down * dropDist;
            isDropped = true;

            audio.Play();

            bool resetDrops = true;

            GameDataScript.score += singleScoreVal;

            foreach (DropScript target in drops)
            {
                if (target.chainID == chainID)
                {
                    if (!target.isDropped)
                    {
                        resetDrops = false;
                    }
                }
            }
            if (resetDrops)
            {
                GameDataScript.score += allScoreVal;

                Invoke("ResetDrops", resetDelay);
            }
        }
    }

    void ResetDrops()
    {
        foreach (DropScript target in drops)
        {
            if (target.chainID == chainID)
            {
                target.transform.position += Vector3.up * dropDist;
                target.isDropped = false;
            }
        }
    }
}


