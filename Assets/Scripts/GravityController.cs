using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    [HideInInspector]
    public Transform mouseHack;
    public float gravityStrength;
    public bool isEnabled = true;
    [HideInInspector]
    public bool isRotating;
    public float distanceToRotate;

    public float maxDisableMouseTime;
    float mouseDisableTimer;
    bool isTiming = false;

    
    Vector3 gravityDirection;
    Rigidbody rigidBody;
    MouseLook mouseLook;
    RaycastHit currentSurface;


    bool weAreChangingGravity;
    // Start is called before the first frame update
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        gravityDirection = Vector3.down;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate(){
        if (isEnabled){
            rigidBody.velocity += gravityDirection * gravityStrength * Time.fixedDeltaTime;
        }
    
    }

    public void ChangeGravity(Vector3 newDirection, Vector3 axisToRotateAround){
        gravityDirection = newDirection;
        weAreChangingGravity = true;

        
        
    }



    // fire ongoing laser between eyes
    // use that to get distance
    // if distance below threshold
    // do rotate



}
