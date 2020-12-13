using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedChecker : MonoBehaviour
{

    [HideInInspector]
    public bool isGrounded = false;
    // Start is called before the first frame update

    void OnTriggerEnter(Collider c){
        isGrounded = true;
    }

    void OnTriggerExit(Collider c){
        isGrounded = false;
    }
}
