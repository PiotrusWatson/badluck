using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChanger : MonoBehaviour, IAbility
{
    HitscanWeapon gravityLaser;
    // Start is called before the first frame update
    void Awake()
    {
        gravityLaser = GetComponent<HitscanWeapon>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        gravityLaser.Fire();
    }

    public void UnActivate()
    {

    }
}
