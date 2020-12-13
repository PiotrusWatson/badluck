using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ShowSpeed : MonoBehaviour
{
    Rigidbody player;
    public TMP_Text text;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        text.text = "" + string.Format("{0:0.00}", player.velocity.magnitude) + "m/s";
    }
}
