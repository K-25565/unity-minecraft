using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    // Public Variables
    public Vector3 Spawn = new Vector3();

    // Global Variables
    private GenBasicWorld WorldGenerator = null;
    private GameObject Player = null;
    
    // Use this for initialization
	private void Start ()
    {
        // Initialize the WorldGenerator and Player variables
        WorldGenerator = GameObject.Find("World Generator").GetComponent<GenBasicWorld>();
        Player = GameObject.FindWithTag("Player");
        // Setup the player's spawn
        SetupSpawn();        
	}
	
	private void SetupSpawn()
    {
        // Set the spawn Vector3 to the middle of the map
        Spawn = new Vector3(((WorldGenerator.ChunkSizeX * WorldGenerator.ChunkGridSize) / 2), (WorldGenerator.ChunkSizeY + 5), ((WorldGenerator.ChunkSizeZ * WorldGenerator.ChunkGridSize) / 2));
        // Move the player to the spawn
        Player.GetComponent<Rigidbody>().MovePosition(Spawn);
    }
}
