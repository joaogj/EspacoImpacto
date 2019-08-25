﻿using UnityEngine;
using System.Collections;

public class RepeatingBackground : MonoBehaviour 
{
    
    private BoxCollider2D groundCollider;       //This stores a reference to the collider attached to the Ground.
    private float groundVerticalLength;       //A float to store the x-axis length of the collider2D attached to the Ground GameObject.

    //Awake is called before Start.
    private void Awake ()
    {
        //Get and store a reference to the collider2D attached to Ground.
        groundCollider = GetComponent<BoxCollider2D> ();
        //Store the size of the collider along the x axis (its length in units).
        groundVerticalLength = groundCollider.size.y;
    }

    //Update runs once per frame
    private void Update()
    {
        //Check if the difference along the x axis between the main Camera and the position of the object this is attached to is greater than groundVerticalLength.
        if (transform.position.y < -groundVerticalLength)
        {
            //If true, this means this object is no longer visible and we can safely move it forward to be re-used.
            RepositionBackground ();
        }
    }

    //Moves the object this script is attached to right in order to create our looping background effect.
    private void RepositionBackground()
    {
        //This is how far to the right we will move our background object, in this case, twice its length. This will position it directly to the right of the currently visible background object.
        Vector3 groundOffSet = new Vector3(0, groundVerticalLength * 1.999f, 1);

        //Move this object from it's position offscreen, behind the player, to the new position off-camera in front of the player.
        transform.position = (Vector3) transform.position + groundOffSet;
    }
}