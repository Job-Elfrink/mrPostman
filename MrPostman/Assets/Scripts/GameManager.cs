using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject pauseMenu;
    public GameObject winScreen;

    public int dierenHonger = 0;

    private void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        if (pauseMenu != null)
        {
            if (Input.GetKeyDown(KeyCode.Escape) || (Input.GetKeyDown(KeyCode.P)))
            {
                Toggle();
            }
        }

        if (dierenHonger == 0)
        {
            winScreen.SetActive(true);
            Debug.Log("GEWONNEN");
            Cursor.lockState = CursorLockMode.None;
        } 
    }

    public void Toggle()
    {

        if (pauseMenu != null)
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);

            if (pauseMenu.activeSelf)
            {
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0f;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1f;
            }
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void OpenScene(string Scene)
    {
        SceneManager.LoadScene(Scene);
    }

    public void LevelRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void StopGame()
    {
        Application.Quit();
    }
}
