using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonScripts : MonoBehaviour {

    public void MM_Quit()
    {
        Application.Quit();
    }

    public void MM_Options()
    {

    }

    public void MM_CreateAWorld()
    {
        // Start loading the new scene and when that's done, destroy the old scene.
        SceneManager.LoadSceneAsync("World Generation Menu");       
    }

    public void GM_Back()
    {
        // Start loading the new scene and when that's done, destroy the old scene.
        SceneManager.LoadSceneAsync("Main Menu");
    }

    public void GM_Generate()
    {
        // Get an access point for the GVS and the GVS' gameobject.
        GenVarStorage GenVarStorage = GameObject.Find("Generation Variable Storage").GetComponent<GenVarStorage>();
        GameObject GenVarStorageObject = GenVarStorage.gameObject;
        // Make separate variables for the Chunk sizes
        int ChunkGridSize = 0;
        int ChunkSizeX = 0;
        int ChunkSizeZ = 0;
        // Try to convert the numbers in the input field and put them in the newly created variables.
        int.TryParse(GameObject.Find("CGT").GetComponent<Text>().text, out ChunkGridSize);
        int.TryParse(GameObject.Find("CXT").GetComponent<Text>().text, out ChunkSizeX);
        int.TryParse(GameObject.Find("CZT").GetComponent<Text>().text, out ChunkSizeZ);
        // Pass the new variables to the GVS.
        GenVarStorage.ChunkGridSize = ChunkGridSize;
        GenVarStorage.ChunkSizeX = ChunkSizeX;
        GenVarStorage.ChunkSizeZ = ChunkSizeZ;
        // Give the GVS immunity whent the scene changes.
        DontDestroyOnLoad(GenVarStorageObject);
        // Start loading the new scene and when that's done, destroy the old scene.
        SceneManager.LoadScene("World");
        SceneManager.UnloadSceneAsync("World Generation Menu");
    }
}
