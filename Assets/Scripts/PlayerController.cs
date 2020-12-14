using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    MovementController movementController;
    GravityController gravityController;

    float horizontalInput, verticalInput;
    // Start is called before the first frame update
    void Awake()
    {
        movementController = GetComponent<MovementController>();
        gravityController = GetComponent<GravityController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonUp("ChangeGravity")){ 
           Transform cameraTransform = Camera.main.transform;
           gravityController.ChangeGravity(cameraTransform.forward, cameraTransform.right * -1);
       }

        if (Input.GetButton("Slide")){
            movementController.SetSliding(true);
        }
        
        if (Input.GetButtonUp("Slide")){
            movementController.SetSliding(false);
        }

    }

    void FixedUpdate(){
        movementController.Move(horizontalInput, verticalInput);

    }
}
