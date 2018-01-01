using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightBlock : MonoBehaviour
{
    private void OnMouseOver()
    {
        gameObject.GetComponentInChildren<Renderer>().material.shader = Shader.Find("FX/Flare");    
    }

    private void OnMouseExit()
    {
        gameObject.GetComponentInChildren<Renderer>().material.shader = Shader.Find("Standard");
    }
}
