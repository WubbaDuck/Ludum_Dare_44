using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void LoadFirstLevel()
    {
        SceneManager.LoadScene(1);
    }

    void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    void PauseGame()
    {

    }

    // void QuitGame()
    // {
    //     System.Diagnostics.Process.GetCurrentProcess().Kill();
    // }
}
