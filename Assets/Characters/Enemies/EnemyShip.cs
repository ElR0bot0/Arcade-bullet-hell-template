using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public float Health {
        set{
            health = value;
            if (health <= 0){
                animator.SetBool("Dead", true);
            }
        }

        get {
            return health;
        }
    }
    
    Collider2D BlastCollider;
    Animator animator;
    public float health = 1;
    // Start is called before the first frame update
    void Start()
    {
        BlastCollider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Dies(){
        
        Destroy(gameObject);
    }
}
