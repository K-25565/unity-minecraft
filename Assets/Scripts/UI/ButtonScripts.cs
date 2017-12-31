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
        SceneManager.UnloadSceneAsync("Main Menu");
    }

    public void GM_Back()
    {
        SceneManager.LoadSceneAsync("Main Menu");
        SceneManager.UnloadSceneAsync("World Generation Menu");
    }

    public void GM_Generate()
    {
        SceneManager.LoadSceneAsync("World");
        GenBasicWorld WorldGenerator = GameObject.Find("World Generator").GetComponent<GenBasicWorld>();

        int ChunkGridSize = 0;
        int ChunkSizeX = 0;
        int ChunkSizeZ = 0;

        int.TryParse(GameObject.Find("CGT").GetComponent<Text>().text, out ChunkGridSize);
        int.TryParse(GameObject.Find("CXT").GetComponent<Text>().text, out ChunkSizeX);
        int.TryParse(GameObject.Find("CZT").GetComponent<Text>().text, out ChunkSizeZ);

        WorldGenerator.ChunkGridSize = ChunkGridSize;
        WorldGenerator.ChunkSizeX = ChunkSizeX;
        WorldGenerator.ChunkSizeZ = ChunkSizeZ;

        SceneManager.UnloadSceneAsync("World Generator");
    }
}
