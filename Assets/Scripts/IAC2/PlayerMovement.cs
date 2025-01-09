using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public float speed = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ; // Freeze rotation and Z position
    }

    // Update is called once per frame
    void Update() 
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Set animator parameter based on input
        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("vertical", vertical);

        // Move the player manually based on input
        Vector3 move = new Vector3(horizontal, 0, vertical).normalized;
        rb.velocity = new Vector3(move.x*speed, rb.velocity.y, move.z * speed);
    }

   
}
