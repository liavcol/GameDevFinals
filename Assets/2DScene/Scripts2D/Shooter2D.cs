using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter2D : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifeTime = 5f;
    [SerializeField] float firingRate = 0.2f;
    [SerializeField] bool useAI;

    public bool isFiring;

    Coroutine firingCoroutine;
    AudioPlayer2D audioPlayer;

    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer2D>();
    }

    void Start()
    {
        if (useAI)
        {
            isFiring = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (isFiring && firingCoroutine == null)
        {
            //firingCoroutine= StartCoroutine(FireContinuosly());
            firingCoroutine = StartCoroutine(FireContinuosly());
        }
        else if (!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    IEnumerator FireContinuosly()
    {
        while (true)
        {
            GameObject instance = Instantiate(projectilePrefab,
                                              transform.position,
                                              Quaternion.identity);

            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if(rb != null)
            {
                rb.velocity = transform.up * projectileSpeed;
            }
            Destroy(instance, projectileLifeTime);

            audioPlayer.PlayShootingClip();

            yield return new WaitForSeconds(firingRate);
            

        }
    }
}
