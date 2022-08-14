using System.Collections;
using UnityEngine;

public class BigEyeBehaviour : MonoBehaviour
{
    [SerializeField]
    private Weapon weapon;

    private Transform player;
    
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(AttackRoutine());
    }
    private void Update()
    {
        if(player)
            transform.LookAt(player.position);
    }
    private IEnumerator AttackRoutine()
    {
        System.Random random = new();
        while (true)
        {
            if (weapon)
                weapon.Shoot(player.gameObject.layer);
            yield return new WaitForSeconds(random.Next(10));
        }
    }
}
