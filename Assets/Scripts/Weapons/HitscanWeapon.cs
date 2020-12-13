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

    

    // also: damage, ammo, clipSize, switchSpeed
    
    // Start is called before the first frame update
    void Awake()
    {
        visibleLaser = GetComponent<LineRenderer>();
        // assumes there will always be a camera somewhere above the gun. might not always be true?
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
        
        visibleLaser.positionCount = 2;
        Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out whereDidIHit);
        visibleLaser.SetPosition(0, transform.position);
        visibleLaser.SetPosition(1, whereDidIHit.point);
        laserTimer = 0f;
    }

    public RaycastHit GetHitData(){
        return whereDidIHit;
    }
}
