using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.General
{
    public class Spawnable : MonoBehaviour
    {

        
        private string[] Objectivelist = { "None", "All", "Enemy", "Player" };


        public enum Objective : int { None = 0, All = 1, Player = 2, Enemy = 3 }
        [Header("Movement Attributes")]
        public Objective objective;
        public float DamagePower = 1;

        [Header("Movement Attributes")]
        public float Speed = 1f;
        public float Rotation = 0f;
        public float DurationOfLife = 0f;
        private Vector2 spawnpoint;
        private float timer = 0f;


        [Header("Relative Movement Attributes")]
        public float RelativeSpeed = 5f; // Speed of the object
        public float startTime = 0f; // Starting time
        public float endTime = 10f; // Ending time
        public AnimationCurve trajectoryX; // Animation curve for X position
        public AnimationCurve trajectoryY; // Animation curve for Y position
        private Vector2 RelativePoint;
        // Start is called before the first frame update
        public virtual void Start()
        {
            spawnpoint = new Vector2(transform.position.x, transform.position.y);
        }

        // Update is called once per frame
        public virtual void Update()
        {
            if (timer > DurationOfLife && DurationOfLife!=0) Destroy(this.gameObject);
            timer += Time.deltaTime;
            RelativePoint = Movement(timer);
            transform.position = RelativePoint + RelativeMovement(timer);
        }

        private Vector2 Movement(float timer)
        {
            float x = timer * Speed * transform.right.x;
            float y = timer * Speed * transform.right.y;
            return new Vector2(x + spawnpoint.x, y + spawnpoint.y);
        }

        private Vector2 RelativeMovement(float timer)
        {
            // If we reached the end of the trajectory, reset time
            if (timer > endTime)
            {
                timer = startTime;
            }

            // Evaluate trajectory curves to get position
            float x = trajectoryX.Evaluate(timer);
            float y = trajectoryY.Evaluate(timer);

            // Move the object
            return new Vector2(x, y) * RelativeSpeed;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(objective != Objective.None)
            {
                if (other.gameObject.transform.parent != null)
                {
                    // Get the parent GameObject of the collided object
                    GameObject parentObject = other.gameObject.transform.parent.gameObject;

                    // Try to get the component from the parent GameObject
                    if (parentObject.TryGetComponent<EnemyShip>(out var enemy) && (objective == Objective.Enemy || objective == Objective.All))
                    {
                        enemy.Health -= DamagePower;
                        Destroy(gameObject);
                    }
                }
                if (other.TryGetComponent<PlayerHealth>(out var player) && objective == Objective.Player || objective == Objective.All)
                {
                    player.Health -= DamagePower;
                    Destroy(gameObject);
                }
            }
        }

        public virtual void Dies()
        {
            Destroy(gameObject);
        }
    }
}
