using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockStats : MonoBehaviour
{
    // Public Variables
    public int BlockHealth = 1;
    public Object BlockType = null;
    
    // Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        CheckBlockHealth();
	}

    void CheckBlockHealth()
    {
        if (BlockHealth <= 0)
        {
            if (gameObject.name.Contains("Bedrock") || gameObject.name.Contains("Barrier"))
            {
                BlockHealth = 100;
            }
            else
            {
                Destroy(gameObject);
            }           
        }
    }
}
