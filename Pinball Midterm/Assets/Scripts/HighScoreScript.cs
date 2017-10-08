using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreScript : MonoBehaviour {

    public static int highScore = 387500;

    Text highScoreDisplay;

	void Start ()
    {
        highScoreDisplay = GetComponent<Text>();

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
