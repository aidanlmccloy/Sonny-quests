using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float multiplier = 10f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Untagged"))
        {
            print(other.tag);
            //print(other.CompareTag("Untagged"));
            Rigidbody stats = other.GetComponent<Rigidbody>();
            //stats.mass *= multiplier; 
            Destroy(gameObject);
        }
    }

}