using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    private float maxHealth = 100f;
    private float health = 50f;
    private bool damageable = true;
    private float damageWaitTime = 1.0f;
    private bool isDead = false;

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
        health -= amount;

        if (health <= 0)
        {
            health = 0;
            Die();
        }
    }

    public void Die()
    {
        isDead = true;
        Debug.LogError("Death Not Implemented");
    }

    public bool IsVampireDead()
    {
        return isDead;
    }
}
