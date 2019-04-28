using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    [SerializeField] private float damageAmount = 20f;
    [SerializeField] private float damageVelocityVertical = 20f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (GetComponent<CompositeCollider2D>().IsTouchingLayers(LayerMask.GetMask("Characters")))
        {
            collision.gameObject.GetComponent<HealthManager>().DecreaseHealth(damageAmount);
            collision.rigidbody.velocity = new Vector2(collision.rigidbody.velocity.x, damageVelocityVertical);
        }
    }
}
