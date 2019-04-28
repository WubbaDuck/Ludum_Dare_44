using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    [SerializeField] private float damageAmount = 20f;
    [SerializeField] private float damageVelocityVertical = 20f;
    [SerializeField] private float damageWaitLength = 0.1f;

    private GameObject lastVictim;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (GetComponent<CompositeCollider2D>().IsTouchingLayers(LayerMask.GetMask("Characters")))
        {
            lastVictim = collision.gameObject;
            HealthManager hm = lastVictim.GetComponent<HealthManager>();
            hm.DecreaseHealth(damageAmount);
            hm.SetDamageable(false);
            collision.rigidbody.velocity = new Vector2(collision.rigidbody.velocity.x, damageVelocityVertical);
            StartCoroutine(DamageTimer(hm));
        }
    }

    // This time is completed in the damage handler to allow for easier changes in time between damage instances depending on the hazard.
    IEnumerator DamageTimer(HealthManager manager)
    {
        yield return new WaitForSecondsRealtime(damageWaitLength);
        manager.SetDamageable(true);
    }
}
