using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {

    public float dropDist = 1f;
    public float resetDelay = 0.5f;

    public int chainID = 0;
    public int scoreVal = 10000;

    public static List<ButtonScript> drops = new List<ButtonScript>();

    public bool isDropped = false;

    private void Start()
    {
        drops.Add(this);
    }

    private void OnCollisionEnter()
    {
        if (!isDropped)
        {
            transform.position += Vector3.left * dropDist;
            isDropped = true;

            bool resetDrops = true;

            foreach (ButtonScript target in drops)
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
                GameDataScript.score += scoreVal;

                Invoke("ResetDrops", resetDelay);
            }
        }
    }

    void ResetDrops()
    {
        foreach (ButtonScript target in drops)
        {
            if (target.chainID == chainID)
            {
                target.transform.position += Vector3.right * dropDist;
                target.isDropped = false;
            }
        }
    }
}
