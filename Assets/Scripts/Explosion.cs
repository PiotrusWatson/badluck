using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    Animator explosionAnimator;
    public float explosionForce;

    void Awake()
    {
        explosionAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void KillSelf(){
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other){
        Rigidbody otherRigidbody = other.GetComponent<Rigidbody>();
        if (otherRigidbody){
            Vector3 explosionDirection = Vector3.Normalize(other.transform.position - transform.position);
            otherRigidbody.AddForce(explosionDirection * explosionForce);
        }
    }
}
