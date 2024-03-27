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

    private float currentTime = 0f; // Current time
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
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public override void Update()
    {
        // Increment time
        currentTime += Time.deltaTime;

        // If we reached the end of the trajectory, reset time
        if (currentTime > endTime)
        {
            currentTime = startTime;
        }

        // Evaluate trajectory curves to get position
        float x = trajectoryX.Evaluate(currentTime);
        float y = trajectoryY.Evaluate(currentTime);
        
        // Move the object
        transform.position = new Vector3(x, y, 0f) * speed;
    }

    public override void Dies(){
        FindObjectOfType<GameManager>().ScoreUpdate(PointsValueOnKill);
        base.Dies();
    }
}
