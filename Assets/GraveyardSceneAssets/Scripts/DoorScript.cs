using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] private InventoryItem key;

    private Animator _animator;

    public delegate void DoorOpened();
    public event DoorOpened OnDoorOpened;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out Inventory inventory) && inventory.HasItem(key))
        {
            _animator.SetTrigger("Open");
            OnDoorOpened?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            _animator.SetTrigger("Close");
    }
}
