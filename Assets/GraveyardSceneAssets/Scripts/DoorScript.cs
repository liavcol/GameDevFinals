using System;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] 
    private InventoryItem key;

    private Animator _animator;

    public Action OnDoorOpened;

    private void Awake() => TryGetComponent(out _animator);

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out Inventory inventory) && inventory.HasItem(key))
        {
            if (_animator)
                _animator.SetTrigger("Open");
            OnDoorOpened?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && _animator)
            _animator.SetTrigger("Close");
    }
}
