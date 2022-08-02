using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;

    protected int currentHealth;

    public void Awake()
    {
        currentHealth = maxHealth;
    }

    public int CurrentHealth
    {
        get { return currentHealth; }
        set
        { 
            currentHealth = value;
            if (currentHealth > maxHealth)
                currentHealth = maxHealth;
            else if (currentHealth <= 0)
            {
                currentHealth = 0;
                Die();
            }
            OnHealthChanged();
        }
    }

    protected abstract void OnHealthChanged();
    protected abstract void Die();

}
