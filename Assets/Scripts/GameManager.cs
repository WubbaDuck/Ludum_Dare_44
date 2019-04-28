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

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void LoadNextLevel()
    {
        if ((SceneManager.GetActiveScene().buildIndex + 1) > (SceneManager.sceneCountInBuildSettings) - 1)
        {
            LoadMenu();
        }
        else
        {
            LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void LoadFirstLevel()
    {
        LoadLevel("Level_001");
    }

    public void LoadMenu()
    {
        LoadLevel("Menu");
    }

    public void ReloadCurrentLevel()
    {
        LoadLevel(SceneManager.GetActiveScene().name);
    }

    public void PauseGame()
    {

    }

    // void QuitGame()
    // {
    //     System.Diagnostics.Process.GetCurrentProcess().Kill();
    // }
}
