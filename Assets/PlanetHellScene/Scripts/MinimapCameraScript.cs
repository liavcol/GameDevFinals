using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCameraScript : MonoBehaviour
{
    [SerializeField]
    private Transform followTarget;

    private void Update()
    {
        Vector3 v = followTarget.position;
        v.y = transform.position.y;

        transform.position = v;
    }
}
