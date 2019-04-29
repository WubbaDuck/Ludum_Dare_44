using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitManager : MonoBehaviour
{
    GameManager gm;
    GameObject detectedObject;
    public GameObject topVampire;
    public GameObject bottomVampire;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        // topVampire = GameObject.Find("Top Vampire");
        // bottomVampire = GameObject.Find("Bottom Vampire");
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
        topVampire.GetComponent<VampireMovement>().DisableMovement();
        bottomVampire.GetComponent<VampireMovement>().DisableMovement();
        topVampire.GetComponent<Animator>().SetTrigger("Exit Level");
        bottomVampire.GetComponent<Animator>().SetTrigger("Exit Level");
        yield return new WaitForSecondsRealtime(2.0f);
        gm.LoadNextLevel();
    }
}
