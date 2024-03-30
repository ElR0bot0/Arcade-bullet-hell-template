using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movimiento y Animacion")]
    Vector2 movementInput;
    public float collisionOffset = 0.05f;
    public float moveSpeed = 1f;
    public ContactFilter2D movementFilter;
    private float CameraMoveSpeed = 0f;
    private CameraMovement Camera;
    Animator animator;

    [Header("BulletSpawner")]
    public PlayerBulletSpawner BulletSpawner;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    Rigidbody2D rb;
    private bool isFiring;




    // Start is called before the first frame update
    void Start()
    {
        Camera = FindObjectOfType<CameraMovement>();
        if(Camera != null && Camera.enabled)
        {
            CameraMoveSpeed = Camera.cameraSpeed;
        }
        rb=GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Camera != null && Camera.enabled)
        {
            CameraMoveSpeed = Camera.cameraSpeed;
        }
        else
        {
            CameraMoveSpeed = 0f;
        }
        rb.MovePosition(Vector3.up *CameraMoveSpeed*  Time.deltaTime);
        if (movementInput!= Vector2.zero){
            bool success = TryMove(movementInput);
            
            if(!success){
                success = TryMove(new Vector2(movementInput.x, 0));
                if(!success){
                    _ = TryMove(new Vector2(movementInput.y, 0));
                }
            }
        }else{
            animator.SetBool("Mvdwn", false);
            animator.SetBool("Mvup", false);
        }
        // Check if the left mouse button is being held down
        if (Input.GetMouseButton(0))
        {
            // Execute code while the left mouse button is being held down
            isFiring = true;
            BulletSpawner.isFiring = isFiring;
        }
        else if (isFiring)
        {
            // Execute code when the left mouse button is released
            isFiring = false;
            BulletSpawner.isFiring = isFiring;
        }

        
    }

    private bool TryMove(Vector2 direction)
    {
            int count = rb.Cast(direction,movementFilter, castCollisions, moveSpeed * Time.fixedDeltaTime+collisionOffset);
            if(count==0){
                rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime * direction);
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
    public void OnMove(InputValue movementValue)
    {
        movementInput=movementValue.Get<Vector2>();
    }

    public void OnFire(InputValue value)
    {
       //esto no se como hacer para que funcione la verdad, algun dia lo cambiare pero hasta entonces 
    }
}
