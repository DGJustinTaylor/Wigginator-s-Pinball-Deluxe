using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDataScript : MonoBehaviour {

    public static int score = 0;

    public int lives = 3;

    public Transform spawnPos;

    public GameObject ball;

    public TextMesh scoreDisplay;
    public TextMesh lifeDisplay;

    private bool isGameOver = false;

    private void Update()
    {
        if (lives < 0)
        {
            lifeDisplay.text = "GAME OVER!!!";
            isGameOver = true;
        }

        if (!GameObject.FindGameObjectWithTag("Ball") && !isGameOver)
        {
            lives--;
            Instantiate(ball, spawnPos.position, ball.transform.rotation);

            if (lifeDisplay)
            {
                lifeDisplay.text = "BALLS: " + lives.ToString();
            }
        }

        if(scoreDisplay)
        {
            scoreDisplay.text = "SCORE: " + score.ToString();
        }

        if(isGameOver)
        {
            Destroy(GameObject.FindGameObjectWithTag("Ball"));

            if(Input.GetKeyDown(KeyCode.Return))
            {

                ButtonScript.drops = new List<ButtonScript>();
                DropScript.drops = new List<DropScript>();

                 score = 0;
                SceneManager.LoadScene("Main");
            }
        }
    }
}
