using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitManager : MonoBehaviour
{
    GameManager gm;
    GameObject detectedObject;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (transform.GetChild(0).GetComponent<ExitSignaler>().IsReadyToExit() & transform.GetChild(1).GetComponent<ExitSignaler>().IsReadyToExit())
        {
            ExitRoutine();
            gm.LoadNextLevel();
        }
    }

    void ExitRoutine()
    {
        Debug.Log("Exiting Level");
    }
}
