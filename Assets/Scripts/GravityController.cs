using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    public float gravityStrength;
    public bool isEnabled = true;
    public float distanceToRotate;
    
    Vector3 gravityDirection;
    Rigidbody rigidBody;
    MouseLook mouseLook;
    RaycastHit currentSurface;

    public Vector3 xAxis;
    public Vector3 yAxis;


    bool weAreChangingGravity;
    // Start is called before the first frame update
    void Awake()
    {
        xAxis = Vector3.right;
        yAxis = Vector3.up;
        rigidBody = GetComponent<Rigidbody>();
        gravityDirection = Vector3.down;
        mouseLook = GetComponentInChildren<MouseLook>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit whatDidIHit;
        if (weAreChangingGravity){
            bool iHitAThing = Physics.Raycast(transform.position, gravityDirection, out whatDidIHit);

        if (iHitAThing && whatDidIHit.collider.CompareTag("Level")){
            
            //rotation code
            //transform.Rotate(whatDidIHitnormal * amountToTurn);
            Quaternion whereWeWereLooking = mouseLook.transform.rotation;
            if (Vector3.Distance(transform.position, whatDidIHit.point) <= distanceToRotate){
                // ensure feet are on ground by setting gravity to - ground
                yAxis = whatDidIHit.normal;
                xAxis = CalculateXAxis(gravityDirection, yAxis);
                gravityDirection = yAxis * -1;

                
                Quaternion whereWereRotating = Quaternion.FromToRotation(Vector3.up, whatDidIHit.normal);
                transform.rotation = whereWereRotating;
                mouseLook.transform.rotation = Quaternion.identity;
                weAreChangingGravity = false;
            }
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
        Debug.Log("Where we were looking: " + Camera.main.transform.localRotation);
        gravityDirection = newDirection;
        weAreChangingGravity = true;

        
        
    }


    Vector3 CalculateZAxis(Vector3 direction, Vector3 normal){
        return direction - Vector3.Dot(direction, normal) * normal;

    }
    Vector3 CalculateXAxis(Vector3 direction, Vector3 normal){
        return Vector3.Cross(normal, CalculateZAxis(direction, normal));
    }

    // fire ongoing laser between eyes
    // use that to get distance
    // if distance below threshold
    // do rotate



}
