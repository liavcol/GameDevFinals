using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Weapon primaryWeapon;
    [SerializeField] private Weapon secondaryWeapon;
    [SerializeField] private LayerMask layer;
    [SerializeField] private Transform mountPoint;

    private Camera fpsCamera;

    private void Awake() => fpsCamera = Camera.main;

    private void Update()
    {
        if (Input.GetButton("Fire1"))
            primaryWeapon.Shoot(layer);
        
        if (Input.GetButtonDown("Fire2") && secondaryWeapon)
            SwitchWeapons();

        if (Input.GetButton("Fire3"))
            primaryWeapon.ZoomIn(fpsCamera);
        else
            primaryWeapon.ZoomOut(fpsCamera);
    }

    private void SwitchWeapons()
    {
        (secondaryWeapon, primaryWeapon) = (primaryWeapon, secondaryWeapon);
        secondaryWeapon.gameObject.SetActive(false);
        primaryWeapon.gameObject.SetActive(true);
    }

    private void PickUpWeapon(Weapon newWeapon)
    {
        if (!primaryWeapon)
            primaryWeapon = newWeapon;
        else
        {
            newWeapon.gameObject.SetActive(false);
            secondaryWeapon = newWeapon;
        }

        newWeapon.transform.SetParent(mountPoint, false);
        newWeapon.transform.localPosition = Vector3.zero;
        newWeapon.transform.localRotation = Quaternion.identity;

        SwitchWeapons();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon"))
        {
            PickUpWeapon(other.GetComponent<Weapon>());
            Destroy(other);
        }
    }
}
