using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    public bool isPaused = false;

    [SerializeField]
    private GameObject pauseMenu;

    [SerializeField]
    private Button quitButton;

    [SerializeField]
    private Button returnToMenuButton;

    [SerializeField]
    private Button resumeButton;

    private void Awake()
    {
        quitButton.onClick.AddListener(QuitGame);
        returnToMenuButton.onClick.AddListener(ReturnToMenu);
        resumeButton.onClick.AddListener(ResumeGame);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            if(isPaused)
            {
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
            }
        }
    }

    private void QuitGame()
    {
        Application.Quit();
    }

    private void ReturnToMenu()
    {
        isPaused = false;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        Debug.Log("Return to menu");
    }

    private void ResumeGame()
    {
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }
}
