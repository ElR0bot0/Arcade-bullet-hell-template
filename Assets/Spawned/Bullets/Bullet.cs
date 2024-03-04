using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    private string[] Objectivelist = { "Enemy", "Player" };
    
    public enum Objective : int {Enemy=0, Player=1}
    
    public Objective objective;
    public float DamagePower= 1;
    public float Speed=1f;
    public float Rotation=0f;
    public float Bulletlife=7f;
    private Vector2 spawnpoint;
    private float timer =0f;
    
    Collider2D BlastCollider;
    // Start is called before the first frame update
    void Start()
    {
        spawnpoint = new Vector2(transform.position.x, transform.position.y);
        BlastCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > Bulletlife) Destroy(this.gameObject);
        timer += Time.deltaTime;
        transform.position = Movement(timer);
    }

    private Vector2 Movement(float timer){
        float x = timer * Speed * transform.right.x;
        float y = timer * Speed * transform.right.y;
        return new Vector2(x+spawnpoint.x, y+spawnpoint.y);
    }

     private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag(Objectivelist[(int)objective]))
        {
            if (other.TryGetComponent<EnemyShip>(out var enemy))
            {
                enemy.Health -= DamagePower;
            }
        }
    }
}
