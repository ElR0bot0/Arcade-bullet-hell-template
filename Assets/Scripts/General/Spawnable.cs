using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


namespace Assets.Scripts.General
{
    public class Spawnable : MonoBehaviour
    {

        
        private string[] Objectivelist = { "None", "All", "Enemy", "Player" };
        public enum Objective : int { None = 0, All = 1, Player = 2, Enemy = 3 }
        [Header("Technical Attributes")]
        public Objective objective;
        public float DamagePower = 1;
        public GameObject hitbox;

        [Header("Movement Attributes")]
        public float Speed = 1f;
        public float DurationOfLife = 0f;
        private Vector2 spawnpoint;
        private float timer = 0f;


        [Header("Relative Movement Attributes")]
        public float RelativeSpeed = 5f; // Speed of the object
        public AnimationCurve trajectoryX; // Animation curve for X position
        public AnimationCurve trajectoryY; // Animation curve for Y position
        private Vector2 RelativePoint;
        // Start is called before the first frame update
        public virtual void Start()
        {
            hitbox.GetComponent<HitBox>().DamagePower = DamagePower;
            hitbox.GetComponent<HitBox>().objective = (HitBox.Objective)objective;
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
            // Evaluate trajectory curves to get position
            float x = trajectoryX.Evaluate(timer);
            float y = trajectoryY.Evaluate(timer);

            // Move the object
            return new Vector2(x, y) * RelativeSpeed;
        }

        

        public virtual void Dies()
        {
            Destroy(gameObject);
        }
    }
}
