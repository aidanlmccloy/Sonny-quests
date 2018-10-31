using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finish_line : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        GameObject.Find("Car").SendMessage("Finnish");
    }
}
