using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    [SerializeField] private InventoryUI inventoryUI;

    private List<InventoryItem> items = new List<InventoryItem>();

    public void Collect(InventoryItem item)
    {
        items.Add(item);
        if (inventoryUI != null)
            inventoryUI.Add(item);
    }

    public void Remove(InventoryItem item)
    {
        items.Remove(item);
        if (inventoryUI != null)
            inventoryUI.Remove(item.Id);
    }

    public bool HasItem(InventoryItem item)
    {
        return items.Contains(item);
    }
}
