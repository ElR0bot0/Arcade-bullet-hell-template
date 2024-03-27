using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.General
{
    public class Spawnable : MonoBehaviour
    {
        #region Spawnable attributes
        [Header("Objective attributes")]
        private string[] Objectivelist = { "None", "All", "Enemy", "Player" };
        public enum Objective : int { None = 0, All = 1, Player = 2, Enemy = 3 }
        public Objective objective;
        public float DamagePower = 1;
        [Header("Movement Attributes")]
        public float Speed = 1f;
        public float Rotation = 0f;
        public float DurationOfLife = 7f;
        private Vector2 spawnpoint;
        private float timer = 0f;

        [Header("Relative Movement Attributes")]
        private Vector2 RelativePoint;
        public float RelativeSpeed = 5f; // Speed of the object
        public float startTime = 0f; // Starting time
        public float endTime = 10f; // Ending time
        public AnimationCurve trajectoryX; // Animation curve for X position
        public AnimationCurve trajectoryY; // Animation curve for Y position

        Collider2D BlastCollider;
        #endregion
        // Start is called before the first frame update
        void Start()
        {
            spawnpoint = new Vector2(transform.position.x, transform.position.y);
            BlastCollider = GetComponent<Collider2D>();
        }

        // Update is called once per frame
        public virtual void Update()
        {
            if (timer > DurationOfLife) Destroy(this.gameObject);
            timer += Time.deltaTime;
            RelativePoint = Movement(timer);
            transform.position = RelativeMovement(timer);
        }

        private Vector2 Movement(float timer)
        {
            float x = timer * Speed * RelativePoint.x;
            float y = timer * Speed * RelativePoint.y;
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
                if (other.TryGetComponent<EnemyShip>(out var enemy) && objective == Objective.Enemy || objective == Objective.All)
                {
                    enemy.Health -= DamagePower;
                    Destroy(gameObject);
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
