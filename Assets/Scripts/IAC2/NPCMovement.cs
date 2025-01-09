using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public Animator animator;
    public float speed = 5f;

    void Start() 
    {
        animator = GetComponent<Animator>();
        
    }

    void Update() 
    {
        animator.SetBool("Walk",true);
        transform.position = new Vector3(this.transform.position.x, -27.1f,this.transform.position.z);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }



}
