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
        public float rotationSpeed = 0f;

        private float CameraMoveSpeed;
        private CameraMovement Camera;


        Rigidbody2D rb;

        [Header("Relative Movement Attributes")]
        public AnimationCurve trajectoryX; // Animation curve for X position
        public AnimationCurve trajectoryY; // Animation curve for Y position
        // Start is called before the first frame update
        public virtual void Start()
        {
            Camera = FindObjectOfType<CameraMovement>();
            rb = GetComponent<Rigidbody2D>();
            hitbox.GetComponent<HitBox>().DamagePower = DamagePower;
            
            hitbox.GetComponent<HitBox>().objective = (HitBox.Objective)objective;
            spawnpoint = new Vector2(transform.position.x, transform.position.y);
        }

        // Update is called once per frame
        public virtual void FixedUpdate()
        {

            timer += Time.deltaTime;
            transform.GetChild(0).transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
            CameraMoveSpeed = Camera != null && Camera.enabled ? Camera.cameraSpeed : 0f;
            // Calculate the new position of the object relative to the camera's velocity
            Vector2 newPosition = Movement(timer) + new Vector2(CameraMoveSpeed * timer, 0f);
            if (timer > DurationOfLife && DurationOfLife!=0) Destroy(this.gameObject);
            rb.MovePosition(newPosition);
            transform.GetChild(0).transform.localPosition = RelativeMovement(timer);
        }

        private Vector2 Movement(float timer)
        {
            float x = timer * Speed * transform.right.x;
            float y = timer * Speed * transform.right.y;
            return new Vector2(x + spawnpoint.x, y + spawnpoint.y);
        }

        private Vector2 RelativeMovement(float timer)
        {
            float x = trajectoryX.Evaluate(timer);
            float y = trajectoryY.Evaluate(timer);

            // Calculate relative position based on the parent's position
            Vector2 relativePosition = new(x, y);

            return relativePosition;
        }

        

        public virtual void Dies()
        {
            Destroy(gameObject);
        }
    }
}
