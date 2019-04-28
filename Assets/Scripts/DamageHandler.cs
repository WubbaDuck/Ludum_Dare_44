using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    [SerializeField] private float damageAmount = 20f;
    [SerializeField] private float damageVelocityVertical = 20f;
    [SerializeField] private float damageWaitLength = 0.1f;

    private GameObject lastVictim;
    private bool collisionEnabled = true;
    private AudioSource damageAudio;

    void Start()
    {
        if (GetComponents<AudioSource>().Length > 0)
        {
            damageAudio = GetComponents<AudioSource>() [0];
        }
        else
        {
            damageAudio = GetComponent<AudioSource>();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collisionEnabled && GetComponent<Collider2D>().IsTouchingLayers(LayerMask.GetMask("Characters")))
        {
            collision.otherRigidbody.AddForce(new Vector2(-600, 0));
            lastVictim = collision.gameObject;
            HealthManager hm = lastVictim.GetComponent<HealthManager>();

            if (hm && hm.IsDamageable() && !hm.IsVampireDead()) // If hm is not null
            {
                hm.ApplyDamage(damageAmount);
                hm.SetDamageable(false);
                collision.rigidbody.velocity = new Vector2(0, damageVelocityVertical);

                damageAudio.Play();

                StartCoroutine(DamageTimer(hm));
            }
        }
    }

    public void Disable()
    {
        collisionEnabled = false;
    }

    public void Enable()
    {
        collisionEnabled = false;
    }

    // This time is completed in the damage handler to allow for easier changes in time between damage instances depending on the hazard.
    IEnumerator DamageTimer(HealthManager manager)
    {
        yield return new WaitForSecondsRealtime(damageWaitLength);
        manager.SetDamageable(true);
    }
}
