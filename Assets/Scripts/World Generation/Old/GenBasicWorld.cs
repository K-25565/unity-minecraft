﻿using System.Collections;
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
    public Object GrassMat = null;
    public Object DirtMat = null;
    public Object StoneMat = null;
    public Object BedrockMat = null;

    // Dev Variables
    public bool DevMode = false;

	// Use this for initialization
	void Start ()
    {      
        if (DevMode == true)
        {
            GenerateWorld();
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
        }       
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void GenerateWorld()
    {
        for (int x = 0; x < (ChunkSizeX * ChunkGridSize); x++)
        {
            for (int y = 0; y < ChunkSizeY; y++)
            {
                for (int z = 0; z < (ChunkSizeZ * ChunkGridSize); z++)
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