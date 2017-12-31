using System.Collections;
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

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Get an easy name for the ridgedbody
        Rigidbody PlayerRB = gameObject.GetComponent<Rigidbody>();
        // If the forward key is pressed, go forward by the movement speed.
        if (Input.GetKey(Forward))
        {
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
        // If the jump key is pressed, go up by 200 times the jumpheight.
        if (Input.GetKeyDown(Jump))
        {
            PlayerRB.AddForce(new Vector3(0f, JumpHeight * 200, 0f));
        }
    }
}
