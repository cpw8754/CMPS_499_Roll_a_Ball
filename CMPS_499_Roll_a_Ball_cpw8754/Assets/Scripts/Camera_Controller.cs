using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;
	// Use this for initialization
	void Start ()
    {
        offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.Rotate(0, -.5f, 0);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.Rotate(0, .5f, 0);
        }
    }
}
