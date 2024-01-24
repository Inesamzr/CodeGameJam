using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleporterTrigger : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private CursorLockMode cursorLockMode;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneName);
            Cursor.lockState = cursorLockMode;
            Time.timeScale = 1f;
        }
    }
}
