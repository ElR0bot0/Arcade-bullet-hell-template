using Assets.Scripts.General;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : Spawnable
{
    Animator animator;

    [Header("Stats")]
    public float health = 1;
    public int PointsValueOnKill=10;


    // Start is called before the first frame update
    public override void Start()
    {
        hitbox.GetComponent<HitBox>().PointsValueOnKill= PointsValueOnKill;
        animator = GetComponentInChildren<Animator>();
        base.Start();
    }
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

    public override void Dies(){
        base.Dies();
    }
}
