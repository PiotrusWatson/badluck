using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{

    public Transform mirrorCam;
    public Transform playerCam;
    // Start is called before the first frame update
    void Awake()
    {
        Camera playerCamera = playerCam.GetComponentInChildren<Camera>();
        if (playerCamera != null){
            playerCam = playerCamera.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (playerCam.position - transform.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(direction);

        rotation.eulerAngles = transform.eulerAngles - rotation.eulerAngles;

        mirrorCam.localRotation = rotation;
    }

}
