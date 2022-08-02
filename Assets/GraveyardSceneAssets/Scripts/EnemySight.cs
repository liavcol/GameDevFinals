using UnityEngine;

public class EnemySight : MonoBehaviour
{
    [SerializeField] private Transform start;
    [SerializeField] private float detectionRange = 10;
    [SerializeField] private LayerMask detectionLayer;

    private void Update()
    {
        if (Physics.SphereCast(start.position, 0.5f, transform.forward, out RaycastHit hit, detectionRange, detectionLayer))
            if (hit.transform.TryGetComponent(out Health hp))
                hp.CurrentHealth = 0;
         
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(start.position, transform.forward * detectionRange);
        Vector3 right = new(start.position.x + 0.5f, start.position.y, start.position.z);
        Vector3 left = new(start.position.x - 0.5f, start.position.y, start.position.z);
        Vector3 up = new(start.position.x, start.position.y + 0.5f, start.position.z);
        Vector3 down = new(start.position.x, start.position.y - 0.5f, start.position.z);
        Gizmos.DrawRay(right, transform.forward * detectionRange);
        Gizmos.DrawRay(left, transform.forward * detectionRange);
        Gizmos.DrawRay(up, transform.forward * detectionRange);
        Gizmos.DrawRay(down, transform.forward * detectionRange);
    }
}
