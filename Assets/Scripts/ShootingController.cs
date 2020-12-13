using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{

    public WeaponSelector arsenal;
    uint currentWeapon;
    float scrollWheel;

    void Awake(){
        currentWeapon = 0;
        
    }

    void Start(){
        Switch(currentWeapon);
    }
    

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1")){
            arsenal.Fire();
        }
        else if (Input.GetButtonUp("Fire1")){
            arsenal.UnFire();
        }

        if (Input.GetButton("Fire2")){
            arsenal.AltFire();
        }
        else if (Input.GetButtonUp("Fire2")){
            arsenal.UnAltFire();
        }


        scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        if (scrollWheel > 0){
            Switch(currentWeapon + 1);
        }
        else if (scrollWheel < 0){
            Switch(currentWeapon - 1);
        }

       
    }

    void Switch(uint newWeapon){
        currentWeapon = (newWeapon % arsenal.Size());
        arsenal.SwitchTo((int) (currentWeapon));
    }




}
