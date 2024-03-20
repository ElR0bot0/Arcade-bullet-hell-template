using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blast : MonoBehaviour
{

    Collider2D BlastCollider;
    
    Animator animator;
    public float DamagePower= 1;
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

    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Enemy"){
            EnemyShip enemy = other.GetComponent<EnemyShip>();
            if (enemy != null){
                enemy.Health -= DamagePower;
            }
        }
    }
}
