using System.Collections;
using System.Collections.Generic;

public class ChunkData
{
    // Chunk XYZ in the Chunk Grid
    public int x, y, z;

    // So we can set our Chunk Grid up
    public ChunkData(int _x, int _y, int _z)
    {
        x = _x;
        y = _y;
        z = _z;
    }

    // Names each chunk
    public override string ToString()
    {
        return string.Format("Chunk ({0}, {1}, {2})", x, y, z);
    }
}
