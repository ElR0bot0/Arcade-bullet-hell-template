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
    
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(movementInput!= Vector2.zero){
            rb.Cast(movementInput,movementFilter, castCollisions, moveSpeed * Time.fixedDeltaTime+collisionOffset);
        }
    }
    void OnMove(InputValue movementValue)
    {
        movementInput=movementValue.Get<Vector2>();
    }
}
