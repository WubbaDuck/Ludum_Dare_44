using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    private float maxHealth = 100f;
    private float health = 50f;
    private bool damageable = true;
    private bool isDead = false;
    private GameManager gm;
    private Animator anim;
    private VampireAudio va;

    void Start()
    {
        anim = GetComponent<Animator>();
        gm = FindObjectOfType<GameManager>();
        va = GetComponent<VampireAudio>();
    }

    public float GetHealth()
    {
        return health;
    }

    public void SetHealth(float amount)
    {
        health = amount;

        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    public bool GiveHealth(float amount)
    {
        if ((health + amount) < maxHealth)
        {
            health += amount;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void DecreaseHealth(float amount)
    {
        if (damageable)
        {
            health -= amount;

            if (health <= 0)
            {
                health = 0;
                Die();
            }
        }
    }

    public void ApplyDamage(float amount)
    {
        DecreaseHealth(amount);
        anim.SetTrigger("Damage Taken");
    }

    public void Die()
    {
        isDead = true;
        anim.SetTrigger("Died");
        va.PlaySound_Death();
        Destroy(GetComponent<CapsuleCollider2D>());
        StartCoroutine(ReloadCurrentLevel());
    }

    public bool IsVampireDead()
    {
        return isDead;
    }

    public bool IsDamageable()
    {
        return damageable;
    }

    public void SetDamageable(bool dmgabl)
    {
        damageable = dmgabl;
    }

    IEnumerator ReloadCurrentLevel()
    {
        yield return new WaitForSecondsRealtime(0.5f);

        // Kill the other vampire
        if (!transform.parent.GetChild(0).GetComponent<HealthManager>().IsVampireDead())
        {
            transform.parent.GetChild(0).GetComponent<HealthManager>().Die();
        }

        if (!transform.parent.GetChild(1).GetComponent<HealthManager>().IsVampireDead())
        {
            transform.parent.GetChild(1).GetComponent<HealthManager>().Die();
        }

        yield return new WaitForSecondsRealtime(1.5f);
        gm.ReloadCurrentLevel();
    }
}
