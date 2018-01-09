using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightBlock : MonoBehaviour
{
    private void OnMouseOver()
    {
        // Check if the game is paused
        if (GameObject.Find("GameUI").GetComponent<PauseScript>().Paused == false)
        {
            // When the mouse enters the block, set the block's shader to the highlight
            Shader Highlight = Shader.Find("FX/Flare");

            if (gameObject.name.Contains("Barrier"))
            {
                // Do nothing
            }
            else
            {
                gameObject.transform.Find("Top").GetComponent<Renderer>().material.shader = Highlight;
                gameObject.transform.Find("Bottom").GetComponent<Renderer>().material.shader = Highlight;
                gameObject.transform.Find("Side 1").GetComponent<Renderer>().material.shader = Highlight;
                gameObject.transform.Find("Side 2").GetComponent<Renderer>().material.shader = Highlight;
                gameObject.transform.Find("Side 3").GetComponent<Renderer>().material.shader = Highlight;
                gameObject.transform.Find("Side 4").GetComponent<Renderer>().material.shader = Highlight;
            }
        }
        else
        {
            // Do nothing
        }                        
    }

    private void OnMouseExit()
    {
        // Check if the game is paused
        if (GameObject.Find("GameUI").GetComponent<PauseScript>().Paused == false)
        {
            // When the mouse exits the block, return the block to its default shader.
            Shader Standard = Shader.Find("Standard");

            if (gameObject.name.Contains("Barrier"))
            {
                // Do nothing
            }
            else
            {
                gameObject.transform.Find("Top").GetComponent<Renderer>().material.shader = Standard;
                gameObject.transform.Find("Bottom").GetComponent<Renderer>().material.shader = Standard;
                gameObject.transform.Find("Side 1").GetComponent<Renderer>().material.shader = Standard;
                gameObject.transform.Find("Side 2").GetComponent<Renderer>().material.shader = Standard;
                gameObject.transform.Find("Side 3").GetComponent<Renderer>().material.shader = Standard;
                gameObject.transform.Find("Side 4").GetComponent<Renderer>().material.shader = Standard;
            }
        }
        else
        {
            // Do nothing
        }       
    }
}
