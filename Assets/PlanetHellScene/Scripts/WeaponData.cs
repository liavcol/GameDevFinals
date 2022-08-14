using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class WeaponData : ScriptableObject
{
    [SerializeField]
    private int damage;
    [SerializeField]
    private float range;
    [SerializeField]
    private float zoomMultiplier;
    [SerializeField] 
    private float cooldown;
    

    public int Damage { get { return damage; } }
    public float Range { get { return range; } }
    public float ZoomMultiplier { get { return zoomMultiplier; } }
    public float Cooldown { get { return cooldown; } }
}
