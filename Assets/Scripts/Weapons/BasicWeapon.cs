using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// should refactor this out soon i guess lol its copypastad alt fire stuff
// basic wrapper - this handles firing cooldown and will handle sounds, firing animations, other generic stuff
public class BasicWeapon : MonoBehaviour, IWeaponHandler
{

    public float coolDown;

    public float altCoolDown;

    float altCoolDownTimer;
    float coolDownTimer;
    IWeapon interestingWeapon;
    // Start is called before the first frame update
    void Awake()
    {
        //currently takes the first weapon we see - will make more involved when we need it to
        interestingWeapon = GetComponent<IWeapon>();
    }

    void Start(){
        coolDownTimer = coolDown;
        altCoolDownTimer = altCoolDown;
    }

    // Update is called once per frame
    void Update()
    {
        if (coolDownTimer < coolDown){
            coolDownTimer += Time.deltaTime;
        }

        if (altCoolDownTimer < altCoolDown){
            altCoolDownTimer += Time.deltaTime;
        }
        
    }

    public void Fire()
    {
        if (coolDownTimer < coolDown){
            return;
        }

        coolDownTimer = 0f;
        interestingWeapon.Fire();
    }

    public void AltFire(){

        if (altCoolDownTimer < altCoolDown){
            return;
        }

        altCoolDownTimer = 0f;
        interestingWeapon.AltFire();
    }

    public void UnFire()
    {
        interestingWeapon.UnFire();
    }

    public void UnAltFire()
    {
        interestingWeapon.UnAltFire();
    }
}
