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

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
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

    public void Die()
    {
        isDead = true;
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
        yield return new WaitForSecondsRealtime(2);
        gm.ReloadCurrentLevel();
    }
}
