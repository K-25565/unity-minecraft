using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpRecovery : MonoBehaviour
{
    // Set an easy to find player variable
    GameObject Player = null;

    // Use this for initialization
    private void Start()
    {
        // Assign the Player variable to the actual player
        GameObject FoundPlayer = GameObject.Find("Player");
        Player = FoundPlayer;
    }

    /* 
     * This will automatically be called.
     * DO NOT call it in the script itself!!!
     */
    private void OnTriggerEnter(Collider ObjectCollidedWith)
    {
        // Check if the player collided with the collider
        if (ObjectCollidedWith.gameObject.tag == "Player")
        {
            // Reset the IsJumping variable in the player script
            Player.GetComponent<PlayerMovement>().IsJumping = false;
        }
        else
        {
            // Do nothing
        }
        
    }
}
