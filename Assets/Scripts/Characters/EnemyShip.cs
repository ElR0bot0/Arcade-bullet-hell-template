using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{

    Collider2D BlastCollider;
    Animator animator;
    public float health = 1;
    public int PointsValueOnKill=10;
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
        FindObjectOfType<GameManager>().ScoreUpdate(PointsValueOnKill);
        Destroy(gameObject);
    }
}
