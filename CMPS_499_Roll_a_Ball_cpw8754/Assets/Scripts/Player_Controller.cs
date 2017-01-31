using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float speed;
    public float jump;

    private Rigidbody rb;

    [SerializeField]
    private bool inAir = false;

    // Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        //rb.freezeRotation = true;
	}
	

	// Update is called once per frame
	void Update ()
    {
		
	}

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (rb.transform.position.y <= 0.75)
        {
            inAir = false;
        }

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);


        if (!inAir && Input.GetKeyUp(KeyCode.Space))
        {
            movement = new Vector3(moveHorizontal, jump, moveVertical);
            inAir = true;
        }

        rb.AddForce(movement * speed);


    }
}
