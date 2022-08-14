using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health2D : Health
{
    [SerializeField] bool isPlayer; //To seperate between player and enemy score
    //[SerializeField] int health = 50;
    [SerializeField] int score = 50;
    [SerializeField] ParticleSystem hitEffect;

    [SerializeField] bool applyCameraShake;
    CameraShake cameraShake;

    AudioPlayer2D audioPlayer;
    ScoreKeeper2D scoreKeeper;

    void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer2D>();
        scoreKeeper = FindObjectOfType<ScoreKeeper2D>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();

        if(damageDealer != null)
        {
            //TakeDamage(damageDealer.GetDamage()); // If player crush with enemy: reduce player health
            CurrentHealth -= damageDealer.GetDamage();
            PlayHitEffect();
            audioPlayer.PlayDamageClip();
            ShakeCamera();
            damageDealer.Hit(); // If player crush with enemy: enemy will be destroyd
        }
    }

    public int GetHealth()
    {
        return currentHealth;
    }

    /*
    void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    */

    protected override void Die()
    {
        if (!isPlayer) //This is not the player
        {
            scoreKeeper.ModifyScore(score);
        } 
        base.Die();
    }

    void PlayHitEffect()
    {
        if(hitEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }

    void ShakeCamera()
    {
        if(cameraShake!=null && applyCameraShake)
        {
            cameraShake.Play();
        }
    }
}
