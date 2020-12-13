using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{

    public float jumpForce;
    public float jumpHeight;
    public float diveHeight;
    public float diveForce;

    Rigidbody rigidBody;
    GroundedChecker groundedChecker;
    bool jumpInput;


    bool jumpPressed = false;

    bool willJump = false;
    bool isDiving = false;

    InputController inputController;
    // Start is called before the first frame update
    void Awake()
    {
        groundedChecker = GetComponentInChildren<GroundedChecker>();
        inputController = GetComponent<InputController>();
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
         jumpPressed = Input.GetButtonDown("Jump");

         if (Input.GetButtonDown("Dive") && !isDiving){
            rigidBody.AddForce(CalculateDive());
            isDiving = true;
         }
         
         if (jumpPressed){
             willJump = true;
         }
        
        if (willJump && groundedChecker.isGrounded){
            rigidBody.AddForce(CalculateJump());
            willJump = false;
        }

        if (isDiving && groundedChecker.isGrounded){
            isDiving = false;
        }
    }

    Vector3 CalculateJump(){
        return CalculatePush(jumpHeight, jumpForce);
    }

    Vector3 CalculateDive(){
        Vector3 push = inputController.GetMovementInput(Vector3.zero);
        return new Vector3(push.x, diveHeight, push.z) * diveForce;
    }

    Vector3 CalculatePush(float height, float force){
        Vector3 push = Vector3.zero; 
        push += transform.forward;
        push += transform.up * height;
        push += transform.right;
        return push * force;
    }
}
