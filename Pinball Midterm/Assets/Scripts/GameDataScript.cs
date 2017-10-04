using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameDataScript : MonoBehaviour {

    public static int score = 0;

    public int lives = 3;

    public Transform spawnPos;

    public GameObject ball;

    public TextMesh scoreDisplay;
    public TextMesh lifeDisplay;

    private AudioSource audio;

    private bool isGameOver = false;

    private void Start()
    {
        Time.timeScale = 1;

        audio = GetComponent<AudioSource>();
    }

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

            if (lives == 1 || lives == 0)
            {
                audio.Play();
            }

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

            if (Input.GetKeyDown(KeyCode.Return))
            {

                ButtonScript.drops = new List<ButtonScript>();
                DropScript.drops = new List<DropScript>();

                score = 0;
                SceneManager.LoadScene("Main");
            }
        }
    }

    private void OnGUI()
    {
        if (isGameOver)
        {
            string message;

            message = "Click to play again";

            Rect startButton = new Rect(Screen.width / 2 - 70, Screen.height / 3 - 100, 140, 30);
            if (GUI.Button(startButton, message))
            {
                StartGame();
            }

            Rect rect = new Rect(Screen.width / 2 - 100, Screen.height / 2 - 125, 200, 25);
            GUI.Box(rect, "GAME OVER");

            GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 50), "YOUR FINAL SCORE IS: ");
            GUI.Label(new Rect(Screen.width / 2 - 25, Screen.height / 2 - 80, 200, 50), ((int)score).ToString());

        }
    }

    void StartGame()
    {
        isGameOver = false;

        ButtonScript.drops = new List<ButtonScript>();
        DropScript.drops = new List<DropScript>();

        score = 0;

        SceneManager.LoadScene("Main");
    }
}