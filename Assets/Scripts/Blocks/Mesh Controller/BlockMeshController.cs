using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMeshController : MonoBehaviour
{
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
        CheckAroundAllBlocks();
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    private void CheckAroundAllBlocks()
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
    }

    public void CheckAroundSelectedBlock(GameObject OriginalBlock)
    {
        UpRay = new Ray(OriginalBlock.transform.position, new Vector3(0f, 1f, 0f));
        DownRay = new Ray(OriginalBlock.transform.position, new Vector3(0f, -1f, 0f));
        XLeftRay = new Ray(OriginalBlock.transform.position, new Vector3(-1f, 0f, 0f));
        XRightRay = new Ray(OriginalBlock.transform.position, new Vector3(1f, 0f, 0f));
        ZLeftRay = new Ray(OriginalBlock.transform.position, new Vector3(0f, 0f, -1f));
        ZRightRay = new Ray(OriginalBlock.transform.position, new Vector3(0f, 0f, 1f));

        // Hit a block above, toggle that block's bottom mesh
        if (Physics.Raycast(UpRay, out UpHit, 1f))
        {
            if (UpHit.transform.gameObject.tag == "Block")
            {
                ToggleMesh(UpHit.transform.gameObject, 2, true);
            }          
        }
        // Hit a block below, toggle that block's top mesh
        if (Physics.Raycast(DownRay, out DownHit, 1f))
        {
            if (DownHit.transform.gameObject.tag == "Block")
            {
                ToggleMesh(DownHit.transform.gameObject, 1, true);
            }
        }
        // Hit a block on the ZRight, toggle the block's ZRight mesh
        if (Physics.Raycast(ZRightRay, out ZRightHit, 1f))
        {
            if (ZRightHit.transform.gameObject.tag == "Block")
            {
                ToggleMesh(ZRightHit.transform.gameObject, 3, true);
            }
        }
        // Hit a block on the ZLeft, toggle the block's ZLeft mesh
        if (Physics.Raycast(ZLeftRay, out ZLeftHit, 1f))
        {
            if (ZLeftHit.transform.gameObject.tag == "Block")
            {
                ToggleMesh(ZLeftHit.transform.gameObject, 4, true);
            }
        }
        // Hit a block on the XRight, toggle the block's XRight mesh
        if (Physics.Raycast(XRightRay, out XRightHit, 1f))
        {
            if (XRightHit.transform.gameObject.tag == "Block")
            {
                ToggleMesh(XRightHit.transform.gameObject, 6, true);
            }
        }
        // Hit a block on the XLeft, toggle the block's XLeft mesh
        if (Physics.Raycast(XLeftRay, out XLeftHit, 1f))
        {
            if (XLeftHit.transform.gameObject.tag == "Block")
            {
                ToggleMesh(XLeftHit.transform.gameObject, 5, true);
            }
        }
    }

    void ToggleMesh(GameObject Block, int Side, bool Toggle)
    {
        switch (Side)
        {
            case 1:
                if (Block.GetComponent<BlockStats>().BlockType == "Barrier")
                {
                    // Do nothing
                }
                else
                {
                    Block.transform.Find("Top").GetComponent<MeshRenderer>().enabled = Toggle;
                }               
                break;

            case 2:
                if (Block.GetComponent<BlockStats>().BlockType == "Barrier")
                {
                    // Do nothing
                }
                else
                {
                    Block.transform.Find("Bottom").GetComponent<MeshRenderer>().enabled = Toggle;
                }               
                break;

            case 3:
                if (Block.GetComponent<BlockStats>().BlockType == "Barrier")
                {
                    // Do nothing
                }
                else
                {
                    Block.transform.Find("Side 1").GetComponent<MeshRenderer>().enabled = Toggle;
                }                
                break;

            case 4:
                if (Block.GetComponent<BlockStats>().BlockType == "Barrier")
                {
                    // Do nothing
                }
                else
                {
                    Block.transform.Find("Side 2").GetComponent<MeshRenderer>().enabled = Toggle;
                }                
                break;

            case 5:
                if (Block.GetComponent<BlockStats>().BlockType == "Barrier")
                {
                    // Do nothing
                }
                else
                {
                    Block.transform.Find("Side 3").GetComponent<MeshRenderer>().enabled = Toggle;
                }               
                break;

            case 6:
                if (Block.GetComponent<BlockStats>().BlockType == "Barrier")
                {
                    // Do nothing
                }
                else
                {
                    Block.transform.Find("Side 4").GetComponent<MeshRenderer>().enabled = Toggle;
                }                
                break;

            default:
                break;
        }
    }
}
