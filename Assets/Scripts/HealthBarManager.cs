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
        topVampHealthManager = transform.parent.GetChild(0).GetComponent<HealthManager>();
        bottomVampHealthManager = transform.parent.GetChild(1).GetComponent<HealthManager>();
        topHealthBarFillTransform = transform.GetChild(0).GetChild(0);
        bottomHealthBarFillTransform = transform.GetChild(1).GetChild(0);

    }

    void Update()
    {
        topHealthBarFillTransform.localScale = new Vector3(((float) topVampHealthManager.GetHealth()) / 100f, 1, 1);
        bottomHealthBarFillTransform.localScale = new Vector3(((float) bottomVampHealthManager.GetHealth()) / 100f, 1, 1);
    }
}
