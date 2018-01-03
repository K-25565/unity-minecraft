using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideBlocks : MonoBehaviour
{
    Ray UpRay = new Ray();
    Ray DownRay = new Ray();
    Ray XLeftRay = new Ray();
    Ray XRightRay = new Ray();
    Ray ZLeftRay = new Ray();
    Ray ZRightRay = new Ray();
    RaycastHit UpHit;
    RaycastHit DownHit;
    RaycastHit XLeftHit;
    RaycastHit XRightHit;
    RaycastHit ZLeftHit;
    RaycastHit ZRightHit;

    // Use this for initialization
	void Start ()
    {
        SetupRays();
        InvokeRepeating("CheckAroundBlock", 0, 0.1f);
	}

    void CheckAroundBlock()
    {             
        // Top - 1
        if (Physics.Raycast(UpRay, out UpHit, 1f))
        {
            if (UpHit.transform.gameObject.tag == "Block")
            {
                ToggleMesh(1, false);                
            }           
        }
        else
        {
            ToggleMesh(1, true);
        }
        // Bottom - 2
        if (Physics.Raycast(DownRay, out DownHit, 1f))
        {
            if (DownHit.transform.gameObject.tag == "Block")
            {
                ToggleMesh(2, false);
            }
        }
        else
        {
            ToggleMesh(2, true);
        }
        // S1 - 3
        if (Physics.Raycast(ZLeftRay, out ZRightHit, 1f))
        {
            if (ZRightHit.transform.gameObject.tag == "Block")
            {
                ToggleMesh(3, false);
            }
        }
        else
        {
            ToggleMesh(3, true);
        }
        // S2 - 4
        if (Physics.Raycast(ZRightRay, out ZLeftHit, 1f))
        {
            if (ZLeftHit.transform.gameObject.tag == "Block")
            {
                ToggleMesh(4, false);
            }
        }
        else
        {
            ToggleMesh(4, true);
        }
        // S3 - 5
        if (Physics.Raycast(XRightRay, out XRightHit, 1f))
        {
            if (XRightHit.transform.gameObject.tag == "Block")
            {
                ToggleMesh(5, false);
            }
        }
        else
        {
            ToggleMesh(5, true);
        }
        // S4 - 6
        if (Physics.Raycast(XLeftRay, out XLeftHit, 1f))
        {
            if (XLeftHit.transform.gameObject.tag == "Block")
            {
                ToggleMesh(6, false);
            }
        }
        else
        {
            ToggleMesh(6, true);
        }
    }

    void ToggleMesh(int Side, bool Toggle)
    {
        switch (Side)
        {
            case 1:
                gameObject.transform.Find("Top").GetComponent<MeshRenderer>().enabled = Toggle;
                break;

            case 2:
                gameObject.transform.Find("Bottom").GetComponent<MeshRenderer>().enabled = Toggle;
                break;

            case 3:
                gameObject.transform.Find("Side 1").GetComponent<MeshRenderer>().enabled = Toggle;
                break;

            case 4:
                gameObject.transform.Find("Side 2").GetComponent<MeshRenderer>().enabled = Toggle;
                break;

            case 5:
                gameObject.transform.Find("Side 3").GetComponent<MeshRenderer>().enabled = Toggle;
                break;

            case 6:
                gameObject.transform.Find("Side 4").GetComponent<MeshRenderer>().enabled = Toggle;
                break;

            default:
                break;
        }
    }

    void SetupRays()
    {
        UpRay = new Ray(gameObject.transform.position, new Vector3(0f, 1f, 0f));
        DownRay = new Ray(gameObject.transform.position, new Vector3(0f, -1f, 0f));
        XLeftRay = new Ray(gameObject.transform.position, new Vector3(-1f, 0f, 0f));
        XRightRay = new Ray(gameObject.transform.position, new Vector3(1f, 0f, 0f));
        ZLeftRay = new Ray(gameObject.transform.position, new Vector3(0f, 0f, -1f));
        ZRightRay = new Ray(gameObject.transform.position, new Vector3(0f, 0f, 1f));
    }
}
