using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Diagonal_Movement : MonoBehaviour
{
    [SerializeField]
    public float speed;
    private Vector3 startingPosition;
    private Vector3 endingPosition;
    private float distanceToTravel;
    private float startingTime;
    private bool atEnd;
    private bool atBeginning;
    // Use this for initialization
    void Start()
    {
        startingPosition = this.transform.position;
        endingPosition = new Vector3(-startingPosition.x, startingPosition.y, -startingPosition.z);
        distanceToTravel = Vector3.Distance(startingPosition, endingPosition);
        startingTime = Time.time;
        atBeginning = true;
        atEnd = false;
    }

    // Update is called once per frame
    void Update()
    {
        //float distCover = (Time.time - startingTime) * speed;
        //float partOfJourney = distCover / distanceToTravel;

        if (transform.position == endingPosition)
        {
            atEnd = true;
            atBeginning = false;
            startingTime = Time.time;
        }

        if (transform.position == startingPosition)
        {
            atEnd = false;
            atBeginning = true;
            //startingTime = Time.time;
        }

        float distCover = (Time.time - startingTime) * speed;
        float partOfJourney = distCover / distanceToTravel;

        if (atEnd)
        {
            //distanceToTravel = Vector3.Distance(endingPosition, startingPosition);
            //distCover = (Time.time - startingTime) * speed;
            //partOfJourney = distCover / distanceToTravel;
            startingPosition = this.transform.position;
            endingPosition = new Vector3(-startingPosition.x, startingPosition.y, -startingPosition.z);
            transform.position = Vector3.Lerp(startingPosition, endingPosition, partOfJourney);
        }

        if (atBeginning)
        {
            transform.position = Vector3.Lerp(startingPosition, endingPosition, partOfJourney);
        }
    }
}
