using System;
using UnityEngine;
using UnityEngine.Events;

public class Item : MonoBehaviour
{
    [SerializeField] private InventoryItem inventoryItem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.TryGetComponent(out Inventory inventory))
            {
                inventory.Collect(inventoryItem);
                Destroy(gameObject);
            }
        }
    }
}
