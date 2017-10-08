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

    public AudioSource[] sounds;
    public AudioSource audio1;
    public AudioSource audio2;
    public AudioSource audio3;

    public int audioCount = 0;

    public static bool isGameOver = false;

    private void Start()
    {
        Time.timeScale = 1;

        sounds = GetComponents<AudioSource>();
        audio1 = sounds[0];
        audio2 = sounds[1];
        audio3 = sounds[2];


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
                audio1.Play();
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

        if (isGameOver)
        {
            if (audioCount == 0 && !audio2.isPlaying)
            {
                audio2.Play();
                audioCount++;
            }

            if (score > HighScoreScript.highScore)
            {
                HighScoreScript.highScore = score;
                PlayerPrefs.SetInt("High Score", HighScoreScript.highScore);

                audio2.Stop();
                audio3.Play();

            }

            Destroy(GameObject.FindGameObjectWithTag("Ball"));

            if (Input.GetKeyDown(KeyCode.Return))
            {

                isGameOver = false;

                ButtonScript.drops = new List<ButtonScript>();
                DropScript.drops = new List<DropScript>();

                lives = 3;
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

        lives = 3;
        score = 0;

        SceneManager.LoadScene("Main");
    }
}