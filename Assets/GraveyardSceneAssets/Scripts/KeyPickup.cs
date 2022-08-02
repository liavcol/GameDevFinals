using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum KeyColor
{
    RED,
    GREEN,
    BLUE
}

public class KeyPickup : MonoBehaviour
{
    [SerializeField]
    private KeyColor color;

    public KeyColor Color
    {
        get { return color; }
    }
}
