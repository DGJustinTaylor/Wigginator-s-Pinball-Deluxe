using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    public Canvas quitMenu;

    public Button startButton;
    public Button exitButton;

    public int levelToLoad = 0;

	void Start ()
    {

        quitMenu = quitMenu.GetComponent<Canvas>();

        startButton = startButton.GetComponent<Button>();
        exitButton = exitButton.GetComponent<Button>();

        quitMenu.enabled = false;

        Time.timeScale = 1;
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
        ButtonScript.drops = new List<ButtonScript>();
        DropScript.drops = new List<DropScript>();

        GameDataScript.score = 0;

        SceneManager.LoadScene(levelToLoad);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
