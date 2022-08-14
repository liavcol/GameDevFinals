using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private new Rigidbody rigidbody;
    private Vector3 startPoint;
    private WeaponData weaponData;

    public static void InstantiateProjectile(GameObject projectile, Vector3 position, Quaternion rotation, WeaponData weaponData, LayerMask layer)
    {
        projectile.SetActive(false);
        GameObject go = Instantiate(projectile, position, rotation);
        go.GetComponent<Projectile>().weaponData = weaponData;
        go.layer = layer;
        go.SetActive(true);
    }

    private void Awake() => rigidbody = GetComponent<Rigidbody>();

    private void Start() => startPoint = transform.position;

    private void FixedUpdate()
    {
        rigidbody.velocity = transform.forward * speed;
        if (Vector3.Distance(startPoint, transform.position) >= weaponData.Range)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.layer != other.gameObject.layer)
            return;
        Debug.Log("trigger");
        if (other.TryGetComponent(out Health h))
            h.CurrentHealth -= weaponData.Damage;
    }
}
