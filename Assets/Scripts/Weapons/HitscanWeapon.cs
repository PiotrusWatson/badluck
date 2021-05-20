using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class HitscanWeapon : MonoBehaviour
{
    GameObject playerCamera;
    LineRenderer visibleLaser;
    public float laserLifeTime;
    float laserTimer;
    RaycastHit whereDidIHit;
    public float range;
    public float bounceLimit;

    

    // also: damage, ammo, clipSize, switchSpeed
    
    // Start is called before the first frame update
    void Awake()
    {
        visibleLaser = GetComponent<LineRenderer>();
        // assumes there will always be a camera somewhere above the gun in hierarchy. might not always be true?
        playerCamera = GetComponentInParent<Camera>().gameObject;
    }

    void Start(){
        visibleLaser.startWidth = .2f;
        visibleLaser.endWidth = .2f;
        laserTimer = laserLifeTime;
    }

    // Update is called once per frame
    void Update()
    {
         if (laserTimer < laserLifeTime){
            laserTimer += Time.deltaTime;
        }
        else{
            visibleLaser.positionCount = 0;
        }

        
    }

    public void Fire()
    {
        //fire laser
        visibleLaser.positionCount = 1;
        bool isHit = true;
        int bounceCount = 0;
        Vector3 startPoint = playerCamera.transform.position;
        Vector3 direction = playerCamera.transform.forward;
        visibleLaser.SetPosition(0, transform.position);
        while (isHit && bounceCount < bounceLimit){
            visibleLaser.positionCount += 1;
            bounceCount += 1;
            isHit = Physics.Raycast(startPoint, direction, out whereDidIHit, range);
            
            if (!isHit){
                visibleLaser.SetPosition(bounceCount, direction * range + startPoint);
                laserTimer = 0f;
                return;
            }
            visibleLaser.SetPosition(bounceCount, whereDidIHit.point);
            startPoint = whereDidIHit.point;
            //reflection
            Vector3 incomingLaser = whereDidIHit.point - playerCamera.transform.position;
            direction = Vector3.Reflect(incomingLaser, whereDidIHit.normal);

        }
       laserTimer = 0f;
        
    }

    public RaycastHit GetHitData(){
        return whereDidIHit;
    }
}
