using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FovController : MonoBehaviour
{
    Camera mainCamera;

    float fov;
    // Start is called before the first frame update
    void Awake()
    {
        mainCamera = GetComponent<Camera>();
        fov = mainCamera.fieldOfView;
    }

    public void zoom(float newFov)
    {
        mainCamera.fieldOfView = newFov;
    }

    public void unZoom()
    {
        mainCamera.fieldOfView = fov;
    }

    public void changeFov(float newFov)
    {
        zoom(newFov);
        fov = newFov;
    }
}
