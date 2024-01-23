using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{

    [SerializeField]
    private Button startButton;

    [SerializeField]
    private Button quitButton;


    void Awake()
    {
        startButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(QuitGame);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void QuitGame()
    {
        Application.Quit();
    }

    private void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("DevScene");
    }
}
