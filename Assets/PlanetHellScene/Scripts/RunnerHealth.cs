using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerHealth : Health
{
    [SerializeField]
    private GameObject drop;

    protected override void Die()
    {
        GetComponent<Animator>().SetTrigger("Die");
        if (drop)
        {
            Instantiate(drop, transform.position, Quaternion.identity);
            drop = null;
        }

        base.Die();
    }
}
