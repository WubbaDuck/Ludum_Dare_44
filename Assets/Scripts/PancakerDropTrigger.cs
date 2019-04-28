using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PancakerDropTrigger : MonoBehaviour
{
    private BoxCollider2D triggerZone;

    void Start()
    {
        triggerZone = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        // Disable damage dealing once the pancaker touches the ground
        if (gameObject.transform.GetChild(0).gameObject.GetComponent<Collider2D>().IsTouchingLayers(LayerMask.GetMask("Border")))
        {
            gameObject.transform.GetChild(0).gameObject.GetComponent<DamageHandler>().Disable();
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name.Contains("Vampire"))
        {
            gameObject.transform.GetChild(0).gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }

}
