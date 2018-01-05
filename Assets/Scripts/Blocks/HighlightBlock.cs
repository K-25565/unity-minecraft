using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightBlock : MonoBehaviour
{
    private void OnMouseOver()
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

    private void OnMouseExit()
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
}
