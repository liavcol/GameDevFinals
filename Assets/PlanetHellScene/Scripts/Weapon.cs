using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] 
    protected WeaponData weaponData;

    protected bool canShoot = true;
    protected bool isZoomed = false;
    protected float ogFOV;

    protected new Animation animation;
    protected AudioSource audioSource;

    private void Awake()
    {
        animation = GetComponent<Animation>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable() => canShoot = true;

    public virtual void Shoot(LayerMask layer)
    {
        if (!canShoot)
            return;

        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, weaponData.Range, layer))
            if (hit.collider.TryGetComponent(out Health health))
                health.CurrentHealth -= weaponData.Damage;
        
        if(animation)
            animation.Play();
        if(audioSource)
            audioSource.Play();

        StartCoroutine(CoolDown());
    }

    public void ZoomIn(Camera cam)
    {
        if (!isZoomed)
        {
            ogFOV = cam.fieldOfView;
            isZoomed = true;
        }
        cam.fieldOfView = ogFOV / weaponData.ZoomMultiplier;
    }
    
    public void ZoomOut(Camera cam)
    {
        if (isZoomed)
        {
            isZoomed = false;
            cam.fieldOfView = ogFOV;
        }
    }

    protected IEnumerator CoolDown()
    {
        canShoot = false;
        yield return new WaitForSeconds(weaponData.Cooldown);
        canShoot = true;
    }
}
