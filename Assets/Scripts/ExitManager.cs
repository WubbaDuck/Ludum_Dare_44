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
            StartCoroutine(ExitRoutine());
        }
    }

    IEnumerator ExitRoutine()
    {
        GameObject.Find("Top Vampire").GetComponent<VampireMovement>().DisableMovement();
        GameObject.Find("Bottom Vampire").GetComponent<VampireMovement>().DisableMovement();
        GameObject.Find("Top Vampire").GetComponent<Animator>().SetTrigger("Exit Level");
        GameObject.Find("Bottom Vampire").GetComponent<Animator>().SetTrigger("Exit Level");
        yield return new WaitForSecondsRealtime(2.0f);
        gm.LoadNextLevel();
    }
}
