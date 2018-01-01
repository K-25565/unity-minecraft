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
            Ray Ray = gameObject.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit Hit;

            if (Physics.Raycast(Ray, out Hit, 100))
            {
                if (Hit.transform.gameObject.tag == "Block")
                {
                    Hit.transform.gameObject.GetComponent<BlockStats>().BlockHealth -= BlockDamageAmount;
                }
                else
                {
                    // Do nothing
                }
            }
        }
        else if (Input.GetMouseButton(PlaceButton))
        {
            Ray Ray2 = gameObject.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit Hit2;

            if (Physics.Raycast(Ray2, out Hit2, 100))
            {
                Vector3 BlockBelowPos = Hit2.transform.position;

                Instantiate(BlockToPlace, new Vector3(BlockBelowPos.x, (BlockBelowPos.y + 1), BlockBelowPos.z), Quaternion.identity);
            }
        }
        else
        {

        }
    }
}
