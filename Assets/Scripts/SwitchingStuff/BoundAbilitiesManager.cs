using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundAbilitiesManager : MonoBehaviour
{
    public GameObject[] abilities;
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ActivateAbility(int index)
    {
        abilities[index].GetComponent<IAbility>().Activate();    
    }
}
