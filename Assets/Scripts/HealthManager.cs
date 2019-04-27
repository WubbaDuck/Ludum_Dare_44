using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    private int maxHealth = 100;
    private int health = 50;

    public int GetHealth()
    {
        return health;
    }

    public bool GiveHealth(int amount)
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

    public void ApplyDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.LogError("Death Not Implemented");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
