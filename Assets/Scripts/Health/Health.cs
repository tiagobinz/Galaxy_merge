using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public delegate void OnDieDelegate();
    public delegate void OnTakeDamage(int amount);
    public delegate void OnHealthChanged();

    [SerializeField] int maxHealth = 10;
    bool dead = false;

    public OnDieDelegate onDie;
    public OnTakeDamage onTakeDamage;
    public OnHealthChanged onHealthChanged;

    int health;

    void Start()
    {
        health = maxHealth;
    }

    public void AddHealth(int amount)
    {
        health += amount;
        health = Mathf.Clamp(health, 0, maxHealth);
        if (onHealthChanged != null)
        {
            onHealthChanged.Invoke();
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0 && !dead)
        {
            Die();
        }
        else
        {
            if (onTakeDamage != null)
            {
                onTakeDamage.Invoke(amount);
            }
            if (onHealthChanged != null)
            {
                onHealthChanged.Invoke();
            }
        }
    }

    void Die()
    {
        dead = true;
        health = 0;
        onDie.Invoke();
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public int GetHealth()
    {
        return health;
    }
}
