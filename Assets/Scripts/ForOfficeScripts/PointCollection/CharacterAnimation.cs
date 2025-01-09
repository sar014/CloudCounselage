using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    public void SetWalking(bool isWalking)
    {
        animator.SetBool("Walk",isWalking);
    }
}
