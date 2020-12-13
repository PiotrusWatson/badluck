using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{

    float horizontalInput;
    float verticalInput;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        
    }

    public Vector3 GetMovementInput(Vector3 initialMovement){
        initialMovement += transform.forward * verticalInput;
        initialMovement += transform.right * horizontalInput;
        return initialMovement;
    }
}
