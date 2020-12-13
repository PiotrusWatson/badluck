using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// doom style sprite handler - they will ALWAYS face you!
public class SpriteManager : MonoBehaviour
{
    
    GameObject player;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
    }
}
