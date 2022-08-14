using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEyeHealth : Health
{
    [SerializeField]
    private GameObject explosionEffect;

    protected override void Die()
    {
        Instantiate(explosionEffect, transform.position, Quaternion.identity);
        base.Die();
    }
}
