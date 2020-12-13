using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailGun : MonoBehaviour, IWeapon 
{

    HitscanWeapon laser;
    FovController scope;

    public float zoomAmount;
    // Start is called before the first frame update
    void Awake()
    {
        laser = GetComponent<HitscanWeapon>();
        scope = GetComponentInParent<FovController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire()
    {
        laser.Fire();
    }

    public void UnFire(){
        return;
    }

    public void AltFire()
    {
        scope.zoom(zoomAmount);
    }

    public void UnAltFire()
    {
        scope.unZoom();
    }
}
