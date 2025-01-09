using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToStopNPC : MonoBehaviour
{
    void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("NPC"))
        {
            Destroy(other.gameObject);
        }
        
    }
}
