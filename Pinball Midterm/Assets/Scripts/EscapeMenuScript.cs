using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscapeMenuScript : MonoBehaviour {

    public Transform canvas;

    void Start ()
    {
        canvas.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
    {

            if (canvas.gameObject.activeInHierarchy == false)
            {
                canvas.gameObject.SetActive(true);

                Time.timeScale = 0;
            }

            else
            {
                canvas.gameObject.SetActive(false);

                Time.timeScale = 1;
            }
    }

    public void toMenu()
    {
        SceneManager.LoadScene(0);
    }
}
