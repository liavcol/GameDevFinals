using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Health
{
    [SerializeField] private Text healthHUD;
    [SerializeField] private GameObject gameOverCamera;
    [SerializeField] private GameOverMenu gameOverCanvas;

    private void Start()
    {
        if (healthHUD)
            healthHUD.text = $"Health: {currentHealth}";
    }

    protected override void OnHealthChanged()
    {
        if(healthHUD)
            healthHUD.text = $"Health: {currentHealth}";
    }

    protected override void Die()
    {
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
    }
}
