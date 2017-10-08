using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreScript : MonoBehaviour {

    public static int highScore = 0;

    Text highScoreDisplay;

	void Start ()
    {
        highScoreDisplay = GetComponent<Text>();

        //PlayerPrefs.SetInt("High Score", 0);

        if (PlayerPrefs.GetInt("High Score") > highScore)
        {
            highScore = PlayerPrefs.GetInt("High Score");
        }

        if (highScoreDisplay)
        {
            highScoreDisplay.text = "High Score: " + highScore.ToString();
        }

    }
}
