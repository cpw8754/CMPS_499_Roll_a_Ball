﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float speed;
    public float jump;

    public Text countText;
    public Text winText;

    private Rigidbody rb;

    private int count;

    [SerializeField]
    private bool inAir = false;

    // Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        //rb.freezeRotation = true;
	}
	

	// Update is called once per frame
	void Update ()
    {
        if (rb.transform.position.y <= 0.75)
        {
            inAir = false;
        }
	}

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //if (rb.transform.position.y <= 0.75)
        //{
        //    inAir = false;
        //}

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);


        if (!inAir && Input.GetKeyUp(KeyCode.Space))
        {
            movement = new Vector3(moveHorizontal, jump, moveVertical);
            inAir = true;
        }

        rb.AddForce(movement * speed);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 9)
        {
            winText.text = "You Win!";
        }
    }
}
