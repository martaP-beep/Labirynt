using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float mouseSensitive = 100;
    Transform playerBody;
    float rotation = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = transform.parent;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        CameraRotation();
    }

    void CameraRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitive * Time.deltaTime;

        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitive * Time.deltaTime;

        rotation -= mouseY;
        rotation = Mathf.Clamp(rotation, -90, 90);

        transform.localRotation = Quaternion.Euler(rotation,0,0);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
