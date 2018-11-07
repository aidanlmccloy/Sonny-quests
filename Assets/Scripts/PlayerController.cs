using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private int count;
    private bool Finish = false; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }
    void Update()
    {
        if (transform.position.y < -6)
        {
            transform.position = new Vector3(1.25f, .45f, -3.75f);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up") || other.gameObject.CompareTag("Pick Up 2") || other.gameObject.CompareTag("Pick Up 3"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        if ((count >= 3) && (other.gameObject.CompareTag("finish")))
        {
            Finish = true;
        }
        if (Finish == true)
        {
          //  winText.text = "Congratulations! You have discovered the keyboard, collected all coins, and jumped to the flag!";
        }
    }
    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString();
    }
}