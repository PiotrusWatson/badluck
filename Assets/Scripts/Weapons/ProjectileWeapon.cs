using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BasicWeapon))]
public class ProjectileWeapon : MonoBehaviour
{
    
    GameObject playerCamera;   
    public GameObject projectilePrefab;


    

    // Start is called before the first frame update
    void Awake()
    {
        playerCamera = GetComponentInParent<Camera>().gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire(){
        GameObject projectile = Instantiate(projectilePrefab, playerCamera.transform.position, playerCamera.transform.rotation);
        

    }
    
}
