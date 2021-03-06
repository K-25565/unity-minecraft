﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Public Variables
    public int MovementSpeed = 1;
    public int JumpHeight = 1;

    public string Forward = string.Empty;
    public string Backward = string.Empty;
    public string Left = string.Empty;
    public string Right = string.Empty;
    public string Jump = string.Empty;

    public bool IsJumping = false;

    // Update is called once per frame
    void Update()
    {    
        // Check if the game is paused
        if (GameObject.Find("GameUI").GetComponent<PauseScript>().Paused == false)
        {
            // Get an easy name for the ridgedbody
            Rigidbody PlayerRB = gameObject.GetComponent<Rigidbody>();            

            // If the forward key is pressed, go forward by the movement speed.
            if (Input.GetKey(Forward))
            {
                //PlayerRB.AddForce(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z * MovementSpeed));

                gameObject.transform.Translate(0f, 0f, MovementSpeed * Time.deltaTime);
            }
            // If the backword key is pressed, go backward by the movement speed.
            if (Input.GetKey(Backward))
            {
                gameObject.transform.Translate(0f, 0f, -MovementSpeed * Time.deltaTime);
            }
            // If the left key is pressed, go left by the movement speed.
            if (Input.GetKey(Left))
            {
                gameObject.transform.Translate(-MovementSpeed * Time.deltaTime, 0f, 0f);
            }
            // If the right key is pressed, go right by the movement speed.
            if (Input.GetKey(Right))
            {
                gameObject.transform.Translate(MovementSpeed * Time.deltaTime, 0f, 0f);
            }
            // If the jump key is pressed, check if the player is already jumping.
            if (Input.GetKey(Jump))
            {
                if (IsJumping == true)
                {
                    // Don't let the player jump again
                }
                else
                {
                    // Let the program know the player is jumping
                    IsJumping = true;
                    // The player will go up by 250 times the jumpheight.
                    PlayerRB.AddForce(new Vector3(0f, JumpHeight * 250, 0));
                }
            }
        }
        else
        {
            // Freeze the player
            Rigidbody PlayerRB = gameObject.GetComponent<Rigidbody>();
            PlayerRB.Sleep();
        }
    }
}
