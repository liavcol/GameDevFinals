using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] 
    private float mouseSensitivity = 500;

    private Transform playerTransform;

    private float rotationX = 0;
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerTransform = transform.parent;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

 
        rotationX = Mathf.Clamp(rotationX - mouseY, -90f, 90f);

        playerTransform.Rotate(Vector3.up * mouseX);
        transform.localEulerAngles = new Vector3(rotationX, 0, 0);
    }
}
