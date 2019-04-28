using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderThrowTrigger : MonoBehaviour
{
    [SerializeField] private int boulderThrowForce = 18000;
    private BoxCollider2D triggerZone;

    void Start()
    {
        triggerZone = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name.Contains("Vampire"))
        {
            Rigidbody2D rb = gameObject.transform.GetChild(0).gameObject.GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.AddForce(new Vector2(boulderThrowForce, 0));
            Destroy(gameObject.GetComponent<BoxCollider2D>());
        }
    }
}
