using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearThrowTrigger : MonoBehaviour
{
    [SerializeField] private int spearThrowForceX = -2500;
    [SerializeField] private int spearThrowForceY = 500;
    private BoxCollider2D triggerZone;
    private bool thrown = false;

    void Start()
    {
        triggerZone = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        // Disable damage dealing once the spear touches the ground
        if (thrown && gameObject.transform.GetChild(0).gameObject.GetComponent<Collider2D>().IsTouchingLayers(LayerMask.GetMask("Border", "Interactables")))
        {
            gameObject.transform.GetChild(0).gameObject.GetComponent<DamageHandler>().Disable();
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name.Contains("Vampire"))
        {
            Rigidbody2D rb = gameObject.transform.GetChild(0).gameObject.GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.AddForce(new Vector2(spearThrowForceX, spearThrowForceY));
            Destroy(gameObject.GetComponent<BoxCollider2D>());
            StartCoroutine(ThrownTimer());
        }
    }

    IEnumerator ThrownTimer()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        thrown = true;
    }
}
