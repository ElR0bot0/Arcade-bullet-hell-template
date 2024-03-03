using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blast : MonoBehaviour
{

    Collider2D BlastCollider;
    
    Animator animator;

    private void Start(){
        animator = GetComponent<Animator>();
        BlastCollider = GetComponent<Collider2D>();
    }
    public void StartBlast(){
       animator.SetBool("Shooting", true);
    }

    public void Blast_1HitBox(){
        BlastCollider.enabled = true;
    }

    public void StopBlast(){
        BlastCollider.enabled = false;
        animator.SetBool("Shooting", false);
    }
}
