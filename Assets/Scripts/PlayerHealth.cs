using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Health
{
    [SerializeField] private Text healthHUD;
    [SerializeField] private GameObject gameOverCamera;
    [SerializeField] private GameOverMenu gameOverCanvas;

    protected override void Start()
    {
        base.Start();
        if (healthHUD)
            healthHUD.text = $"Health: {currentHealth}";
    }

    protected override void HealthChanged()
    {
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
        else if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }

        if (healthHUD)
            healthHUD.text = $"Health: {currentHealth}";
    }

    protected override void Die()
    {
        Debug.Log("Player Died");
        /*
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("HUD"))
            go.SetActive(false);

        if (gameOverCamera)
            gameOverCamera.SetActive(true);

        if (gameOverCanvas)
        {
            gameOverCanvas.gameObject.SetActive(true);
            gameOverCanvas.PlayerWon = false;
        }
        
        Destroy(gameObject);
    */
    }
}
