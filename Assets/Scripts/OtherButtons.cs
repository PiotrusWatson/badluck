using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherButtons : MonoBehaviour
{
    bool cursorToggle = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("CursorToggle")){
            cursorToggle = !cursorToggle;
        }

        if (cursorToggle){
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else{
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
