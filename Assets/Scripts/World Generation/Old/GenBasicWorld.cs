using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenBasicWorld : MonoBehaviour
{
    // Public Variables
    public int ChunkGridSize = 1;
    public int ChunkSizeX = 0;
    public int ChunkSizeY = 0;
    public int ChunkSizeZ = 0;

    // World Gen Options
    public int DirtLayerSize = 0;

    // Block Inventory
    public Object BorderMat = null;
    public Object GrassMat = null;
    public Object DirtMat = null;
    public Object StoneMat = null;
    public Object BedrockMat = null;

    // Dev Variables
    public bool DevMode = false;

	// Use this for initialization
	void Start ()
    {      
        // Check if DevMode is enabled
        if (DevMode == true)
        {
            // Generate the world and then the world border
            GenerateWorld();
            GenerateWorldBorder();
        }
        else
        {
            // Take the variables handed over the the GVS and assign them to the appropriate variables.
            GenVarStorage GVS = GameObject.Find("Generation Variable Storage").GetComponent<GenVarStorage>();
            ChunkGridSize = GVS.ChunkGridSize;
            ChunkSizeX = GVS.ChunkSizeX;
            ChunkSizeZ = GVS.ChunkSizeZ;
            // Destroy the GVS to free up memory.
            Destroy(GVS.gameObject);
            // Generate the world.
            GenerateWorld();
            // Generate the world border.
            GenerateWorldBorder();
        }       
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void GenerateWorld()
    {
        // Run a for loop for the x coordinate to increase it by one
        for (int x = 0; x < (ChunkSizeX * ChunkGridSize); x++)
        {
            // Run a for loop for the y coordinate to increase it by one
            for (int y = 0; y < ChunkSizeY; y++)
            {
                // Run a for loop for the z coordinate to increase it by one
                for (int z = 0; z < (ChunkSizeZ * ChunkGridSize); z++)
                {
                    // If this is the grass layer, generate the grass layer
                    if (y == (ChunkSizeY - 1))
                    {
                        Instantiate(GrassMat, new Vector3(x, y, z), Quaternion.identity);
                    }
                    // If this is the dirt layer, generate the dirt layer
                    else if (y > (ChunkSizeY - DirtLayerSize))
                    {
                        Instantiate(DirtMat, new Vector3(x, y, z), Quaternion.identity);
                    }
                    // If this is the stone layer, generate the stone layer
                    else if (y > 0)
                    {
                        Instantiate(StoneMat, new Vector3(x, y, z), Quaternion.identity);
                    }
                    // If this is the bedrock layer, generate the bedrock layer
                    else
                    {
                        Instantiate(BedrockMat, new Vector3(x, y, z), Quaternion.identity);
                    }
                }
            }
        }
    }

    void GenerateWorldBorder()
    {
        for (int x = 0; x < (ChunkSizeX * ChunkGridSize); x++)
        {
            for (int y = ChunkSizeY; y < (ChunkSizeY + 5); y++)
            {
                Instantiate(BorderMat, new Vector3(x, y, -1), Quaternion.identity);
                Instantiate(BorderMat, new Vector3(x, y, (ChunkSizeZ * ChunkGridSize)), Quaternion.identity);
            }           
        }
        
        for (int z = 0; z < ((ChunkSizeZ * ChunkGridSize) + 2); z++)
        {
            for (int y = ChunkSizeY; y < (ChunkSizeY + 5); y++)
            {
                Instantiate(BorderMat, new Vector3(-1, y, (z - 1)), Quaternion.identity);
                Instantiate(BorderMat, new Vector3((ChunkSizeX * ChunkGridSize), y, (z - 1)), Quaternion.identity);
            }
        }
        
    }
}
