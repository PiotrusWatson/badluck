using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity;
    public Transform playerBody;
    float xRotation = 0f;

    GravityController gravityController;

    bool isActive = true;
    // Start is called before the first frame update
    void Awake()
    {
        //gravityController = GetComponentInParent<GravityController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive){
            return;
        }
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.fixedDeltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.fixedDeltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.AngleAxis(xRotation, Vector3.right);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    public void ToggleMouse(bool isActive){
        this.isActive = isActive;
    }
}
