using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldChunkGenerator : MonoBehaviour
{
    private WorldData World = new WorldData();

    public Transform ChunkPrefab = null;
    public Transform[,,] ChunkCoords = null;


    // Use this for initialization
    void Start ()
    {
        World.SetupChunkGrid();
        CreateChunks();
	}
	
	private void CreateChunks()
    {
        ChunkCoords = new Transform[World.WorldGridX, World.WorldGridY, World.WorldGridZ];

        for (int x = 0; x < World.WorldGridX; x++)
        {
            for (int y = 0; y < World.WorldGridY; y++)
            {
                for (int z = 0; z < World.WorldGridZ; z++)
                {
                    ChunkData CurrentChunk = World.Chunks[x, y, z];

                    Vector3 ChunkPos = new Vector3(CurrentChunk.x * World.ChunkX, 0, CurrentChunk.z * World.ChunkZ);
                    Transform CreatedChunk = Instantiate(ChunkPrefab, ChunkPos, Quaternion.identity) as Transform;

                    CreatedChunk.parent = transform;
                    CreatedChunk.name = CurrentChunk.ToString();
                    ChunkCoords[x, y, z] = CreatedChunk;
                }
            }
        }
    }
}
