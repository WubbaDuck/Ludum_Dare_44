using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthTransferManager : MonoBehaviour
{
    private float transferStepAmount = 0.25f;
    private float totalHealth = 0f;
    HealthManager topHealthManager;
    HealthManager bottomHealthManager;

    void Start()
    {
        topHealthManager = GameObject.Find("Top Vampire").GetComponent<HealthManager>();
        bottomHealthManager = GameObject.Find("Bottom Vampire").GetComponent<HealthManager>();
    }

    void Update()
    {
        totalHealth = topHealthManager.GetHealth() + bottomHealthManager.GetHealth();

        // Transfer from top to bottom
        if (Input.GetKey(KeyCode.S))
        {
            if ((topHealthManager.GetHealth() - transferStepAmount) >= 0 && !topHealthManager.IsVampireDead())
            {
                topHealthManager.DecreaseHealth(transferStepAmount);
                bottomHealthManager.GiveHealth(transferStepAmount);
            }
        }

        // Transfer from bottom to top
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if ((bottomHealthManager.GetHealth() - transferStepAmount) >= 0 && !bottomHealthManager.IsVampireDead())
            {
                bottomHealthManager.DecreaseHealth(transferStepAmount);
                topHealthManager.GiveHealth(transferStepAmount);
            }
        }
    }
}
