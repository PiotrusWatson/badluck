using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiGravField : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
       ToggleGravity(other, false);
        
    }

    void OnTriggerExit(Collider other){
        ToggleGravity(other, true);
    }

    void ToggleGravity(Collider other, bool usingGravity){
        GravityController gc = other.GetComponent<GravityController>();
        Rigidbody otherRigidBody = other.GetComponent<Rigidbody>();
        if (gc){
            gc.isEnabled = usingGravity;
        } else if (otherRigidBody) {
            otherRigidBody.useGravity = usingGravity;
        }
        
    }
}
