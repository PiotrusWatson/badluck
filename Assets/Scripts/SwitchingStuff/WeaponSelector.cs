 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelector : MonoBehaviour, IWeaponHandler
{
    public GameObject[] weaponPrefabs;
    private List<GameObject> weapons = new List<GameObject>();

    public BasicWeapon activeWeapon;

    public int index;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (GameObject weaponPrefab in weaponPrefabs){
            GameObject weapon = Instantiate(weaponPrefab, transform);
            weapon.GetComponent<MeshRenderer>().enabled = false;
            weapons.Add(weapon);
        }

        SwitchTo(0);
    }

    // Update is called once per frame
    
    public void Fire(){
        activeWeapon.Fire();
    }

    public void AltFire(){
        activeWeapon.AltFire();
    }

    public void UnFire(){
        activeWeapon.UnFire();
    }

    public void UnAltFire()
    {
        activeWeapon.UnAltFire();
    }

    public byte Size(){
        return (byte) (weaponPrefabs.Length);
    }

    public void SwitchTo(int index){
        this.index = index;
        GameObject activeWeaponObject = weapons[index];
        activeWeaponObject.GetComponent<MeshRenderer>().enabled = true;
        activeWeapon = activeWeaponObject.GetComponent<BasicWeapon>();
    }
}
