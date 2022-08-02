using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    [SerializeField] protected int maxHealth = 100;

    protected int currentHealth;

    private void Start() => currentHealth = maxHealth;

    public int CurrentHealth
    {
        get { return currentHealth; }
        set
        { 
            currentHealth = value;
            OnHealthChanged();
        }
    }

    protected abstract void OnHealthChanged();
    protected abstract void Die();

}
