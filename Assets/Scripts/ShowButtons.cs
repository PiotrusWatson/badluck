using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowButtons : MonoBehaviour
{
    public Image forward;
    public Image backward;
    public Image right;
    public Image left;
    public Image jump;
    // Start is called before the first frame update
    void Awake()
    {
        forward.color = Color.clear;
        backward.color = Color.clear;
        right.color = Color.clear;
        left.color = Color.clear;
        jump.color = Color.clear;

    }

    // Update is called once per frame
    void Update()
    {
        SetImageOnAxis(forward, backward, "Vertical");
        SetImageOnAxis(right, left, "Horizontal");
        jump.color = Color.clear;
        if (Input.GetButton("Jump")){
            jump.color = Color.white;
        }
        
    }

    void SetImageOnAxis(Image one, Image minusOne, string axis){
        float value = Input.GetAxis(axis);
        one.color = Color.clear;
        minusOne.color = Color.clear;
        if (value < 0){
            minusOne.color = Color.white;
        }
        else if (value > 0){
            one.color = Color.white;
        }
    }

    
}
