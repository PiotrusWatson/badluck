using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    //public float groundSpeed;



    public float speedFlibble;
    public float airSpeedLimit;
    public float groundSpeedLimit;
    public float groundAcceleration;
    public float airAcceleration;

   // public float airSpeed;
    Rigidbody rigidBody;
    GroundedChecker groundedChecker;
    Collider feet;
    public PhysicMaterial slidePhysics;
    PhysicMaterial walkPhysics;




    public bool isSliding = false;
    
    float horizontalInput, verticalInput;
    // Start is called before the first frame update
    void Awake()
    {   
        
        groundedChecker = GetComponentInChildren<GroundedChecker>();
        rigidBody = GetComponent<Rigidbody>();
        feet = GetComponent<Collider>();
        walkPhysics = feet.material;
    }


  
    public Vector3 GetDesiredMovement(Vector3 initialMovement){
        initialMovement += transform.forward * verticalInput;
        initialMovement += transform.right * horizontalInput;
        return initialMovement;
    }

    //has to be called every physics frame to make sense
    public void Move(float horizontalMove, float verticalMove){
        horizontalInput = horizontalMove;
        verticalInput = verticalMove; 
        if (isSliding && groundedChecker.isGrounded){
            return;
        }
        
         Vector3 desiredMovement = GetDesiredMovement(Vector3.zero);

         if (groundedChecker.isGrounded){
            Vector3 newVelocity = GetAcceleration(desiredMovement, groundSpeedLimit, groundAcceleration);
            rigidBody.velocity += newVelocity;

        }
        else{
            Vector3 newVelocity = GetAcceleration(desiredMovement, airSpeedLimit, airAcceleration);
            rigidBody.velocity += newVelocity;
        }
        
    }

// stolen from quake 1. makes bhop happen :)
    Vector3 GetAcceleration(Vector3 desiredMovement, float speedLimit, float acceleration){

        //get speed by multiplying all the stuff together n adding it
        float currentSpeed = Vector3.Dot(rigidBody.velocity, desiredMovement);
        //get the desired speed from our desired movement
        float desiredSpeed = Vector3.Magnitude(desiredMovement) * speedFlibble;

        if (desiredSpeed > speedLimit){
            desiredSpeed = speedLimit;
        }
        // get difference - in order to limit acceleration
        float speedToAdd = desiredSpeed - currentSpeed;
        if (speedToAdd < 0){
            speedToAdd = 0;
        }
        // try n accelerate past our speed limit
        float accelSpeed = acceleration * desiredSpeed * Time.fixedDeltaTime;
        if (accelSpeed > speedToAdd){
            accelSpeed = speedToAdd;
        }

        // cool
        return desiredMovement.normalized * accelSpeed;
    }


    public void SetSliding(bool isSliding){
        if (isSliding){
            feet.material = slidePhysics;
        }
        else {
            feet.material = walkPhysics;
        }

        this.isSliding = isSliding;
        
    }

    



}
