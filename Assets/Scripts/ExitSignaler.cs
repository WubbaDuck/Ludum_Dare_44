using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitSignaler : MonoBehaviour
{
    private bool exitReady = false;

    public bool IsReadyToExit()
    {
        return exitReady;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Top Vampire" | collider.gameObject.name == "Bottom Vampire")
        {
            exitReady = true;
        }
    }

    void OnTriggerExit2D()
    {
        exitReady = false;
    }
}
