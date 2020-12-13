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
    InputController inputController;
    
    GravityController gravityController;



    bool isSliding = false;
    
    
    // Start is called before the first frame update
    void Awake()
    {   
        
        groundedChecker = GetComponentInChildren<GroundedChecker>();
        rigidBody = GetComponent<Rigidbody>();
        inputController = GetComponent<InputController>();
        feet = GetComponent<Collider>();
        gravityController = GetComponent<GravityController>();
        walkPhysics = feet.material;
    }


    void Update(){

       if (Input.GetButtonUp("ChangeGravity")){ 
           Transform cameraTransform = Camera.main.transform;
           gravityController.ChangeGravity(cameraTransform.forward, cameraTransform.right * -1);
       }

        if (Input.GetButton("Slide")){
            SetSliding(true);
        }
        
        if (Input.GetButtonUp("Slide")){
            SetSliding(false);
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isSliding && groundedChecker.isGrounded){
            return;
        }
        Vector3 desiredMovement = inputController.GetMovementInput(Vector3.zero);
        //ground movement :)
        if (groundedChecker.isGrounded){
            Vector3 newVelocity = GetAcceleration(desiredMovement, groundSpeedLimit, groundAcceleration);
            rigidBody.velocity += newVelocity;

        }
        else{
            Vector3 newVelocity = GetAcceleration(desiredMovement, airSpeedLimit, airAcceleration);
            rigidBody.velocity += newVelocity;
        }


        //air movement :(
        

        
    }



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


    void SetSliding(bool isSliding){
        if (isSliding){
            feet.material = slidePhysics;
        }
        else {
            feet.material = walkPhysics;
        }

        this.isSliding = isSliding;
        
    }

    



}
