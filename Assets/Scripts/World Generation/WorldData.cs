using System.Collections;
using System.Collections.Generic;

public class WorldData
{
    // Set the Size of a single chunk.
    public int ChunkX = 32;
    public int ChunkY = 128;
    public int ChunkZ = 32;
    // Set up how many chunks you want to generate in the world.
    public int WorldGridX = 8;
    public int WorldGridY = 1;
    public int WorldGridZ = 8;
    // Set up the Chunk array
    public ChunkData[,,] Chunks;
    // setup Parameters for the world grid.
    public const int BottomChunkBorderRow = 0, LeftChunkBorderColumn = 0;
    public int TopChunkBorderRow { get { return WorldGridY - 1; } }
    public int RightChunkBorderColumn { get { return WorldGridX - 1; } }

    public void SetupChunkGrid()
    {
        // Creates the ChunkData array
        Chunks = new ChunkData[WorldGridX, WorldGridY, WorldGridZ];

        for (int x = LeftChunkBorderColumn; x <= RightChunkBorderColumn; x++)
        {
            for (int y = BottomChunkBorderRow; y <= TopChunkBorderRow; y++)
            {
                for (int z = 0; z < WorldGridZ; z++)
                {
                    // Generate the Chunk Grid
                    Chunks[x, y, z] = new ChunkData(x, y, z);
                }
            }
        }
    }    

    
}
