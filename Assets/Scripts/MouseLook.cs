using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 500;
    [SerializeField] private Texture2D cursorTexture;

    private Transform playerTransform;
    
    private float rotationX = 0;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerTransform = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
 
        rotationX = Mathf.Clamp(rotationX - mouseY, -90f, 90f);

        playerTransform.Rotate(Vector3.up * mouseX);
        transform.localEulerAngles = new Vector3(rotationX, 0, 0);
    }
}
