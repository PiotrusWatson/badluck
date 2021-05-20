using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    MovementController movementController;

    float horizontalInput, verticalInput;
    // Start is called before the first frame update
    void Awake()
    {
        movementController = GetComponent<MovementController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

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
