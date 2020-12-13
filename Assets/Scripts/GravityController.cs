using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    public float gravityStrength;
    public bool isEnabled = true;
    

    Vector3 gravityDirection;
    Rigidbody rigidBody;
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
        Vector3 oldDirection = gravityDirection;
        float amountToTurn = Vector3.Angle(oldDirection, newDirection);
        RaycastHit whatDidIHit;
        bool iHitAThing = Physics.Raycast(transform.position, newDirection, out whatDidIHit);
        if (iHitAThing){
            gravityDirection = newDirection;
            //rotation code
            //transform.Rotate(whatDidIHitnormal * amountToTurn);
            transform.rotation = Quaternion.FromToRotation(Vector3.up, whatDidIHit.normal);
            
        }

        
        
    }


}
