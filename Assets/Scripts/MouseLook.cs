using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity;
    public Transform playerBody;
    float xRotation = 0f;
    float yRotation = 0f;
    float offsetX = 0f;
    float offsetY = 0f;
    float storedX, storedY = 0f;

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
        Debug.Log(Input.GetAxis("Mouse X"));
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.fixedDeltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.fixedDeltaTime;

        xRotation -= mouseY;
        //xRotation += offsetX;
        yRotation = mouseX; //+ offsetY
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        storedX = xRotation;
        storedY = yRotation;
        transform.localRotation = Quaternion.AngleAxis(xRotation , Vector3.right);
        playerBody.Rotate(Vector3.up * yRotation);
    }

    public void ToggleMouse(bool isActive){
        if (!isActive){
            StoreOffsets();
        }
        this.isActive = isActive;
    }

    public void StoreOffsets(){
        this.offsetX = storedX;
        this.offsetY = storedY;
    }
}
