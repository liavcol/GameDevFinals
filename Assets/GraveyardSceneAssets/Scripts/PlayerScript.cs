using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private List<KeyColor> keyColors = new List<KeyColor>();

    public bool HasKey(KeyColor color)
    {
        return keyColors.Contains(color);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KeyPickup"))
        {
            keyColors.Add(other.GetComponent<KeyPickup>().Color);
            Destroy(other.gameObject);
        }
    }

    public void PlayerKilled()
    {
        Destroy(GameObject.FindGameObjectWithTag("ObjectivesHUD"));
        Instantiate(Resources.Load("GameOverMenu"), Vector3.zero, Quaternion.identity);
        Destroy(gameObject);
    }

    public void PlayerWon()
    {
        Destroy(GameObject.FindGameObjectWithTag("ObjectivesHUD"));
        Instantiate(Resources.Load("WinningMenu"), Vector3.zero, Quaternion.identity);
        Destroy(gameObject);
    }
}
