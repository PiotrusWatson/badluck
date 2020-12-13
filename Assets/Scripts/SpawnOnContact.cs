using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnContact : MonoBehaviour
{
    public GameObject thingToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision c){
        Instantiate(thingToSpawn, c.GetContact(0).point, Quaternion.identity);
        Destroy(gameObject);
    }
}
