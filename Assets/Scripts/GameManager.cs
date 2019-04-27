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

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadFirstLevel()
    {
        LoadLevel("Level_001");
    }

    public void LoadMenu()
    {
        LoadLevel("Menu");
    }

    public void PauseGame()
    {

    }

    // void QuitGame()
    // {
    //     System.Diagnostics.Process.GetCurrentProcess().Kill();
    // }
}
