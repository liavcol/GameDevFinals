using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{

    [SerializeField] private GameObject inventorySlotUI;
    private Dictionary<int, GameObject> slots = new Dictionary<int, GameObject>();

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
