using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerController : MonoBehaviour
{
    SimpleGameManager GM;
    void Awake()
    {
        GM = SimpleGameManager.Instance;
    }

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
        Debug.Log(other.gameObject.tag);

        if (other.gameObject.CompareTag("PickUp") || other.gameObject.CompareTag("PickUp2") || other.gameObject.CompareTag("PickUp3"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
            GM.FinishQuest(other.gameObject.tag);
        }

        if ((GM.AreQuestsFinished()) && (other.gameObject.CompareTag("finish")))
        {
            winText.text = "Congratulations! You have discovered the keyboard, collected all coins, and jumped to the flag!";
        }
    }
    

    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString();
    }
}