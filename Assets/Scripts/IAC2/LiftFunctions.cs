using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftFunctions : MonoBehaviour
{
    public Manager manager;
    public Animator animator1;
    public bool EnteredLift;

    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            animator1.SetTrigger("Closing");
            manager.OnEnterLift();
            EnteredLift = true;
        }
        
    }

    
    
}
