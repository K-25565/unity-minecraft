using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBlock : MonoBehaviour
{
    // Public Variables
    public int BreakButton = 0; // Left Mouse = 0
    public int PlaceButton = 0; // Right Mouse = 1
    public int BlockDamageAmount = 0;
    public Object BlockToPlace = null;

    // Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        ListenForClick();
	}

    void ListenForClick()
    {
        if (Input.GetMouseButton(BreakButton))
        {
            // Create a Ray and a RaycastHit to go out and hit a block
            Ray Ray = gameObject.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit Hit;
            // If the Ray hit anything
            if (Physics.Raycast(Ray, out Hit, 5))
            {
                // If the Ray hit a Block
                if (Hit.transform.gameObject.tag == "Block")
                {
                    // Minus the Block's health by the block damage amount.
                    Hit.transform.gameObject.GetComponent<BlockStats>().BlockHealth -= BlockDamageAmount;
                }
                else
                {
                    // Do nothing
                }
            }
        }
        else if (Input.GetMouseButtonDown(PlaceButton))
        {
            // Create a Ray and a RacstHit to go out and hit a block
            Ray Ray2 = gameObject.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit Hit2;
            // If the Ray hit anything
            if (Physics.Raycast(Ray2, out Hit2, 5))
            {
                // Find where the block below is
                Vector3 BlockBelowPos = Hit2.transform.position;
                // Create a new block one unit above where the below block is.
                Instantiate(BlockToPlace, new Vector3(BlockBelowPos.x, (BlockBelowPos.y + 1), BlockBelowPos.z), Quaternion.identity);
            }
        }
        else
        {
            // Do nothing...
        }
    }
}
