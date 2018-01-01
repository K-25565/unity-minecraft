using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillLine : MonoBehaviour {

    private void OnTriggerEnter(Collider ObjectCollidedWith)
    {
        Destroy(ObjectCollidedWith.gameObject);
    }
}
