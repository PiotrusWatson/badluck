using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{

    public WeaponSelector arsenal;
    uint currentWeapon;
    float scrollWheel;

    public float nextFireThreshold;
    public float maxFireLength;
    float nextFireTimer;
    float fireLength;
    bool isFiring;


    void Awake(){
        currentWeapon = 0;
        fireLength = maxFireLength;
        nextFireTimer = 0;
        
    }

    void Start(){
        Switch(currentWeapon);
    }
    

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (fireLength < maxFireLength && isFiring){
            arsenal.Fire();
            fireLength += Time.fixedDeltaTime;
        }
        else if (isFiring){
            nextFireTimer = 0;
            isFiring = false;
        }

        if (nextFireTimer < nextFireThreshold && !isFiring){
            nextFireTimer += Time.fixedDeltaTime;
        }
        else if (!isFiring) {
            isFiring = true;
            fireLength = 0;
        }
        


        

       
    }

    void Switch(uint newWeapon){
        currentWeapon = (newWeapon % arsenal.Size());
        arsenal.SwitchTo((int) (currentWeapon));
    }




}
