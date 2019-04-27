using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarManager : MonoBehaviour
{
    HealthManager topVampHealthManager;
    HealthManager bottomVampHealthManager;
    Transform topHealthBarFillTransform;
    Transform bottomHealthBarFillTransform;

    void Start()
    {
        topVampHealthManager = GameObject.Find("Top Vampire").GetComponent<HealthManager>();
        bottomVampHealthManager = GameObject.Find("Bottom Vampire").GetComponent<HealthManager>();
        topHealthBarFillTransform = GameObject.Find("Top Health Bar Fill").transform;
        bottomHealthBarFillTransform = GameObject.Find("Bottom Health Bar Fill").transform;

    }

    void Update()
    {
        topHealthBarFillTransform.localScale = new Vector3(topVampHealthManager.GetHealth() / 100f, 1, 1);
        bottomHealthBarFillTransform.localScale = new Vector3(bottomVampHealthManager.GetHealth() / 100f, 1, 1);
    }
}
