using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] 
    protected int maxHealth = 100;
    [SerializeField]
    protected int deathDelay = 5;

    protected int currentHealth;

    protected virtual void Start() => currentHealth = maxHealth;

    public int CurrentHealth
    {
        get { return currentHealth; }
        set
        { 
            currentHealth = value;
            HealthChanged();
        }
    }

    public Action OnDie;

    protected virtual void HealthChanged()
    {
        if (currentHealth <= 0)
            Die();
    }

    protected virtual void Die()
    {
        foreach (MonoBehaviour mono in GetComponents<MonoBehaviour>())
            mono.enabled = false;
        OnDie?.Invoke();
        Destroy(gameObject, deathDelay);
    }

}
