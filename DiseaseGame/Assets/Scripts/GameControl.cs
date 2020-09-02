using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public GameObject gameOverWindow;

    public void GameOver()
    {
        gameOverWindow.SetActive(true);
        Time.timeScale = 0; //pauses game so that player can no longer move
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
