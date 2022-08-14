using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletWeapon : Weapon
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform barrel;

    public override void Shoot(LayerMask layer)
    {
        if (!canShoot)
            return;
        Projectile.InstantiateProjectile(bullet, barrel.position, transform.rotation, weaponData, layer);
        StartCoroutine(CoolDown());
    }
}
