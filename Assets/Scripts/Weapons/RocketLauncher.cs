using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : MonoBehaviour, IWeapon
{

    ProjectileWeapon gun;

    // Start is called before the first frame update
    void Awake()
    {
        gun = GetComponent<ProjectileWeapon>();
    }

    // Update is called once per frame
    public void Fire()
    {
        gun.Fire();
    }

    public void UnFire()
    {
        return;
    }

    public void AltFire()
    {
        return;
    }

    public void UnAltFire()
    {
        return;
    }
}
