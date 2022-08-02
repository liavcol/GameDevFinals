using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewInventoryItem", menuName = "Inventory Item")]
public class InventoryItem : ScriptableObject
{
    [SerializeField] private int id;
    [SerializeField] private new string name;
    [SerializeField] private Sprite inventorySprite;

    public int Id { get { return id; } }

    public string Name { get { return name; } }
    public Sprite InventorySprite { get { return inventorySprite; } }
}
