using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Countdown : MonoBehaviour
{
    ShootingController player;
    public TMP_Text text;

    public float displayThreshold;
    public float lengthOut;
    Color visibleColour;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<ShootingController>();
        visibleColour = text.color;
        if (displayThreshold > player.nextFireThreshold){
            displayThreshold = player.nextFireThreshold;
        }
        text.color = Color.clear;
    }

    // Update is called once per frame
    void Update()
    {
        float countdown = player.nextFireThreshold - player.nextFireTimer;
        if (countdown <= displayThreshold && countdown > 0){
            text.text = ((int) (countdown + 1)).ToString();
            text.color = visibleColour;
        }
        else if (countdown <= displayThreshold){
            text.color = Color.clear;
        }
    }
}
