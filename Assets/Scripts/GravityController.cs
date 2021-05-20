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
        mouseHack = Instantiate(new GameObject()).transform;
        rigidBody = GetComponent<Rigidbody>();
        gravityDirection = Vector3.down;
        mouseLook = GetComponentInChildren<MouseLook>();

    }

    // Update is called once per frame
    void Update()
    {
        if (mouseDisableTimer < maxDisableMouseTime && isTiming){
            mouseDisableTimer += Time.fixedDeltaTime;
        }
        else if(isTiming)
        {
            mouseLook.ToggleMouse(true);
            isTiming = false;

        }
        
        if (!weAreChangingGravity){
            return;
        }
        RaycastHit whatDidIHit;
        bool iHitAThing = Physics.Raycast(transform.position, gravityDirection, out whatDidIHit);

        if (iHitAThing && whatDidIHit.collider.CompareTag("Level"))
        {
            
            //rotation code
            //transform.Rotate(whatDidIHitnormal * amountToTurn);
            Quaternion whereWeWereLooking = mouseLook.transform.rotation;
            if (Vector3.Distance(transform.position, whatDidIHit.point) <= distanceToRotate){
                // ensure feet are on ground by setting gravity to - ground
                gravityDirection =  whatDidIHit.normal * -1;

                mouseLook.ToggleMouse(false);
                mouseDisableTimer = 0f;
                isTiming = true;

                Quaternion whereWereRotating = Quaternion.FromToRotation(Vector3.up, whatDidIHit.normal);
                transform.rotation = whereWereRotating;
                mouseHack.rotation = whereWereRotating;
                mouseLook.transform.rotation = Quaternion.identity;
                
                weAreChangingGravity = false;

            }
        }
    }

    void FixedUpdate(){
        if (isEnabled){
            rigidBody.velocity += gravityDirection * gravityStrength * Time.fixedDeltaTime;
        }
    
    }

    public void ChangeGravity(Vector3 newDirection, Vector3 axisToRotateAround){
       /* TODELTE Vector3 oldDirection = gravityDirection;
        float amountToTurn = Vector3.Angle(oldDirection, newDirection);*/ 
        gravityDirection = newDirection;
        weAreChangingGravity = true;

        
        
    }



    // fire ongoing laser between eyes
    // use that to get distance
    // if distance below threshold
    // do rotate



}
