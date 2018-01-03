using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMeshController : MonoBehaviour
{
    // Public Variables
    public bool PlayerBrokeBlock = false;

    // Global Variables
    GameObject[] Blocks;
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
        Blocks = GameObject.FindGameObjectsWithTag("Block");
        print(Blocks.Length + " blocks have been generated.");
        CheckAroundBlocks();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (PlayerBrokeBlock == true)
        {
            CheckAroundBlocks();
        }
        else
        {
            // Do nothing...
        }
	}

    void CheckAroundBlocks()
    {
        Blocks = GameObject.FindGameObjectsWithTag("Block");

        foreach (GameObject Block in Blocks)
        {
            UpRay = new Ray(Block.transform.position, new Vector3(0f, 1f, 0f));
            DownRay = new Ray(Block.transform.position, new Vector3(0f, -1f, 0f));
            XLeftRay = new Ray(Block.transform.position, new Vector3(-1f, 0f, 0f));
            XRightRay = new Ray(Block.transform.position, new Vector3(1f, 0f, 0f));
            ZLeftRay = new Ray(Block.transform.position, new Vector3(0f, 0f, -1f));
            ZRightRay = new Ray(Block.transform.position, new Vector3(0f, 0f, 1f));

            // Top - 1
            if (Physics.Raycast(UpRay, out UpHit, 1f))
            {
                if (UpHit.transform.gameObject.tag == "Block")
                {
                    ToggleMesh(Block, 1, false);
                }
            }
            else
            {
                ToggleMesh(Block, 1, true);
            }
            // Bottom - 2
            if (Physics.Raycast(DownRay, out DownHit, 1f))
            {
                if (DownHit.transform.gameObject.tag == "Block")
                {
                    ToggleMesh(Block, 2, false);
                }
            }
            else
            {
                ToggleMesh(Block, 2, true);
            }
            // S1 - 3
            if (Physics.Raycast(ZLeftRay, out ZRightHit, 1f))
            {
                if (ZRightHit.transform.gameObject.tag == "Block")
                {
                    ToggleMesh(Block, 3, false);
                }
            }
            else
            {
                ToggleMesh(Block, 3, true);
            }
            // S2 - 4
            if (Physics.Raycast(ZRightRay, out ZLeftHit, 1f))
            {
                if (ZLeftHit.transform.gameObject.tag == "Block")
                {
                    ToggleMesh(Block, 4, false);
                }
            }
            else
            {
                ToggleMesh(Block, 4, true);
            }
            // S3 - 5
            if (Physics.Raycast(XRightRay, out XRightHit, 1f))
            {
                if (XRightHit.transform.gameObject.tag == "Block")
                {
                    ToggleMesh(Block, 5, false);
                }
            }
            else
            {
                ToggleMesh(Block, 5, true);
            }
            // S4 - 6
            if (Physics.Raycast(XLeftRay, out XLeftHit, 1f))
            {
                if (XLeftHit.transform.gameObject.tag == "Block")
                {
                    ToggleMesh(Block, 6, false);
                }
            }
            else
            {
                ToggleMesh(Block, 6, true);
            }
        }

        PlayerBrokeBlock = false;
    }

    void ToggleMesh(GameObject Block, int Side, bool Toggle)
    {
        switch (Side)
        {
            case 1:
                Block.transform.Find("Top").GetComponent<MeshRenderer>().enabled = Toggle;
                break;

            case 2:
                Block.transform.Find("Bottom").GetComponent<MeshRenderer>().enabled = Toggle;
                break;

            case 3:
                Block.transform.Find("Side 1").GetComponent<MeshRenderer>().enabled = Toggle;
                break;

            case 4:
                Block.transform.Find("Side 2").GetComponent<MeshRenderer>().enabled = Toggle;
                break;

            case 5:
                Block.transform.Find("Side 3").GetComponent<MeshRenderer>().enabled = Toggle;
                break;

            case 6:
                Block.transform.Find("Side 4").GetComponent<MeshRenderer>().enabled = Toggle;
                break;

            default:
                break;
        }
    }
}
