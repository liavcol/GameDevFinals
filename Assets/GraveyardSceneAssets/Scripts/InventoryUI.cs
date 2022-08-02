using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject inventorySlotUI;
    private readonly Dictionary<int, GameObject> slots = new();

    public void Add(InventoryItem inventoryItem)
    {
        GameObject go = Instantiate(inventorySlotUI, transform, false);
        go.GetComponent<Image>().sprite = inventoryItem.InventorySprite;
        slots[inventoryItem.Id] = go;
    }

    public void Remove(int itemId)
    {
        Destroy(slots[itemId]);
        slots.Remove(itemId);
    }
}
