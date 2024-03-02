using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector2 movementInput;
    public float collisionOffset = 0.05f;
    public float moveSpeed =1f;
    public ContactFilter2D movementFilter;
    Animator animator;
    
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(movementInput!= Vector2.zero){
            bool success = TryMove(movementInput);
            
            if(!success){
                success = TryMove(new Vector2(movementInput.x, 0));
                if(!success){
                    success = TryMove(new Vector2(movementInput.y, 0));
                }
            }
        }else{
            animator.SetBool("Mvdwn", false);
            animator.SetBool("Mvup", false);
        }
    }

    private bool TryMove(Vector2 direction)
    {
            int count = rb.Cast(direction,movementFilter, castCollisions, moveSpeed * Time.fixedDeltaTime+collisionOffset);
            if(count==0){
                rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
                //Aqui defino los booleanos de la
                if(direction.y>0){
                    animator.SetBool("Mvdwn", false);
                    animator.SetBool("Mvup", true);
                }else if(direction.y<0){
                    animator.SetBool("Mvdwn", true);
                    animator.SetBool("Mvup", false);
                }else{
                    animator.SetBool("Mvdwn", false);
                    animator.SetBool("Mvup", false);
                }
                return true;
            }else{
                return false;
            }
    }
    void OnMove(InputValue movementValue)
    {
        movementInput=movementValue.Get<Vector2>();
    }
}
