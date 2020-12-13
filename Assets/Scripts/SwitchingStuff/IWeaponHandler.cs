using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* Hacky copy of weapon to ensure we can enforce several important methods in classes that aren't weapons
without having them show up as weapons */
public interface IWeaponHandler 
{
    void Fire();
    void AltFire();

    void UnFire();

    void UnAltFire();
} 

