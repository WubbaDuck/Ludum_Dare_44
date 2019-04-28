using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthTransferManager : MonoBehaviour
{
    private float transferStepAmount = 0.25f;
    private float totalHealth = 0f;
    HealthManager topHealthManager;
    HealthManager bottomHealthManager;
    VampireAudio topVa;
    VampireAudio bottomVa;

    void Start()
    {
        topHealthManager = GameObject.Find("Top Vampire").GetComponent<HealthManager>();
        bottomHealthManager = GameObject.Find("Bottom Vampire").GetComponent<HealthManager>();
        topVa = GameObject.Find("Top Vampire").GetComponent<VampireAudio>();
        bottomVa = GameObject.Find("Bottom Vampire").GetComponent<VampireAudio>();
    }

    void Update()
    {
        if (topHealthManager && bottomHealthManager)
        {
            totalHealth = topHealthManager.GetHealth() + bottomHealthManager.GetHealth();

            if (!bottomHealthManager.IsVampireDead() && !topHealthManager.IsVampireDead())
            {
                // Transfer from top to bottom
                if (Input.GetKey(KeyCode.S))
                {
                    if ((topHealthManager.GetHealth() - transferStepAmount) >= 0)
                    {
                        topHealthManager.DecreaseHealth(transferStepAmount);
                        bottomHealthManager.GiveHealth(transferStepAmount);
                        topVa.PlaySound_Transfusion();
                    }
                }
                else
                {
                    topVa.StopTransfusionSound();
                }

                // Transfer from bottom to top
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    if ((bottomHealthManager.GetHealth() - transferStepAmount) >= 0)
                    {
                        bottomHealthManager.DecreaseHealth(transferStepAmount);
                        topHealthManager.GiveHealth(transferStepAmount);
                        bottomVa.PlaySound_Transfusion();
                    }
                }
                else
                {
                    bottomVa.StopTransfusionSound();
                }
            }
            else
            {
                topVa.StopTransfusionSound();
                bottomVa.StopTransfusionSound();
            }
        }
        else
        {
            topHealthManager = GameObject.Find("Top Vampire").GetComponent<HealthManager>();
            bottomHealthManager = GameObject.Find("Bottom Vampire").GetComponent<HealthManager>();
        }
    }
}
