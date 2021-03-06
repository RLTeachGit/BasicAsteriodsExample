﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipController : MonoBehaviour {




	// Use this for initialization
	void Start () {
		
	}
	
    float   ScreenHeight()
    {
        //Orthograpic camera height is stored in Camera
        return Camera.main.orthographicSize;
    }

    float   ScreenWidth()
    {
        //To get Width use the height and aspect ratio
        return ScreenHeight() * Camera.main.aspect;
    }

    void WrapPosition()
    {
        //Get current width and Height
        float tScreenHeight = ScreenHeight();
        float tScreenWidth = ScreenWidth();
        bool tWrapped = false;      //Flag
        //Keep a copy of the current position, so we can alter it if needed
        Vector3 tWrapPosition = transform.position;

        //Horizontal
        if (transform.position.x > tScreenWidth)
        {  //Check right of screen
            //Adjust screen position to move right by whole screen
            tWrapPosition.x -= tScreenWidth  * 2.0f;
            tWrapped = true; //Set flag so position is updated
        }
        else if (transform.position.x < -tScreenWidth)
        { //Check left of screen
            //Adjust screen position to move left
            tWrapPosition.x += tScreenWidth * 2.0f;
            tWrapped = true; //Set flag so position is updated
        }

        //Vertical
        if (transform.position.y > tScreenHeight)
        {  //Check top of screen
            //Adjust screen position to move down by whole screen
            tWrapPosition.y -= tScreenHeight * 2.0f;
            tWrapped = true; //Set flag so position is updated
        }
        else if (transform.position.y < -tScreenHeight) //Check bottom of screen
        {
            //Adjust screen position to move down
            tWrapPosition.y += tScreenHeight * 2.0f;
            tWrapped = true; //Set flag so position is updated
        }
        if (tWrapped)       //Only adjust position to wrap if needed
        {
            transform.position = tWrapPosition; //Apply new position
        }
    }

    public float Speed = 5.0f;      //Show this in IDE
    //Update GO position based on player input
    void UpdateMovement()
    {
        if (Input.GetKey(KeyCode.RightArrow))       //Is key pressed
        {
            transform.position += Vector3.right * Speed * Time.deltaTime;   //Move to new location
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * Speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.up * Speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.down * Speed * Time.deltaTime;
        }
    }

    // Update is called once per frame
    void Update () {
        UpdateMovement();       //Allows Testing of Movement
        WrapPosition();         //Wrap world
	}
}
