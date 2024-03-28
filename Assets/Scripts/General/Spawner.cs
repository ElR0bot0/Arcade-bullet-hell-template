using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.General
{
    public class Spawner : MonoBehaviour
    {
        enum SpawnerType { Straight, Spin }
        public enum Objective : int { None = 0, All = 1, Player = 2, Enemy = 3 }
        [Header("Spawned Object Attributes")]
        public Objective SpawnedObjective;
        public GameObject Spawned;
        public float SpawnedLife = 5f;
        public float SpawnedSpeed = 1f;
        public float SpawnedRotation = 0f;

        [Header("Spawner Attributes")]
        [SerializeField] private SpawnerType spawner;
        [SerializeField] public float FiringRate = 0.5f;


        [HideInInspector] public GameObject spawnedInstance;
        private float timer = 0f;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        public virtual void Update()
        {
            timer += Time.deltaTime;
            if (spawner == SpawnerType.Spin)
            {
                transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + 1f);
            }
            if (timer >= FiringRate)
            {
                Fire();
                timer = 0;
            }
        }

        public virtual void Fire()
        {
            if (Spawned)
            {
                spawnedInstance = Instantiate(Spawned, transform.position, Quaternion.identity);
                spawnedInstance.GetComponent<Spawnable>().objective = (Bullet.Objective)SpawnedObjective;
                spawnedInstance.GetComponent<Spawnable>().Speed = SpawnedSpeed;
                spawnedInstance.GetComponent<Spawnable>().DurationOfLife = SpawnedLife;
                spawnedInstance.transform.rotation = transform.rotation;
                Transform firstChildTransform = spawnedInstance.transform.GetChild(0);
                // Rotate the first child based on EnemyRotation
                firstChildTransform.rotation = Quaternion.Euler(0f, 0f, SpawnedRotation);
            }
        }
    }
}
