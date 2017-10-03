﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    public Canvas quitMenu;
    public Button startButton;
    public Button exitButton;

	// Use this for initialization
	void Start () {

        quitMenu = quitMenu.GetComponent<Canvas>();

        startButton = startButton.GetComponent<Button>();
        exitButton = exitButton.GetComponent<Button>();

        quitMenu.enabled = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ExitPressed()
    {
        quitMenu.enabled = true;

        startButton.enabled = false;
        exitButton.enabled = false;
    }

    public void NoPressed()
    {
        quitMenu.enabled = false;

        startButton.enabled = true;
        exitButton.enabled = true;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
