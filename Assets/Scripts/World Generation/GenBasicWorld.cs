using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenBasicWorld : MonoBehaviour
{
    // Public Variables
    public int ChunkSizeX = 0;
    public int ChunkSizeY = 0;
    public int ChunkSizeZ = 0;

    // World Gen Options
    public int DirtLayerSize = 0;

    // Block Inventory
    public Object GrassMat = null;
    public Object DirtMat = null;
    public Object StoneMat = null;
    public Object BedrockMat = null;

	// Use this for initialization
	void Start ()
    {       
        GenerateChunk();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void GenerateChunk()
    {
        for (int x = 0; x < ChunkSizeX; x++)
        {
            for (int y = 0; y < ChunkSizeY; y++)
            {
                for (int z = 0; z < ChunkSizeZ; z++)
                {
                    if (y == (ChunkSizeY - 1))
                    {
                        Instantiate(GrassMat, new Vector3(x, y, z), Quaternion.identity);
                    }
                    else if (y > (ChunkSizeY - DirtLayerSize))
                    {
                        Instantiate(DirtMat, new Vector3(x, y, z), Quaternion.identity);
                    }
                    else if (y > 0)
                    {
                        Instantiate(StoneMat, new Vector3(x, y, z), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(BedrockMat, new Vector3(x, y, z), Quaternion.identity);
                    }
                }
            }
        }
    }
}
