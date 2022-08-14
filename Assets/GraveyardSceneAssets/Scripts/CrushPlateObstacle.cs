using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushPlateObstacle : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float minHeightDrop;
    
    private float _minHeight;
    private float _maxHeight;

    private int dir = -1;

    private void Start()
    {
        _minHeight = transform.position.y - minHeightDrop;
        _maxHeight = transform.position.y;
    }

    private void Update()
    {
        float yPos = Mathf.Min(Mathf.Max(transform.position.y + speed*dir*Time.deltaTime, _minHeight), _maxHeight);
        transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
        if (transform.position.y <= _minHeight || transform.position.y >= _maxHeight)
            dir *= -1;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
            collision.gameObject.GetComponent<Health>().CurrentHealth = 0;
    }

}
