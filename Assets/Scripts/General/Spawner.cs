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
        public enum ProjectileRotationType { Absolute, Relative };
        public enum Objective : int { None = 0, All = 1, Player = 2, Enemy = 3 }
        [Header("Spawned Object Attributes")]
        public Objective SpawnedObjective;
        public GameObject Spawned;
        public float SpawnedLife = 5f;
        public float SpawnedSpeed = 1f;
        public ProjectileRotationType ProjectileRotationtype = ProjectileRotationType.Absolute;
        public float SpawnedRotation = 0f;
        public float DamagePower = 1;

        [Header("Spawner Attributes")]
        [SerializeField] private SpawnerType spawner;
        [SerializeField] public float FiringRate = 0.5f;

        [Header("Angular Spawner Attributes")]
        public int NumberOfSpawnPoints = 1; // Number of spawn points along the specified angle
        public float SpawnAngle = 30f; // Angle at which to spawn objects (in degrees)
        public float SpawnRadius = 0.001f; // Radius at which to spawn objects

        [HideInInspector] public GameObject spawnedInstance;
        private float timer = 0f;

        // Start is called before the first frame update
        public virtual void Start()
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
                if(SpawnRadius == 0f || NumberOfSpawnPoints<=1)
                {
                    SpawnInstance(transform.position, NumberOfSpawnPoints);
                }
                else
                {
                    float startAngle = transform.eulerAngles.z - (SpawnAngle / 2); // Start angle of the spawn range
                    float angleIncrement = SpawnAngle / (NumberOfSpawnPoints - 1); // Angle increment between spawn points
                    for (int i = 0; i < NumberOfSpawnPoints; i++)
                    {
                        float angle = startAngle + (i * angleIncrement); // Calculate angle for the current spawn point
                        float x = Mathf.Cos(angle * Mathf.Deg2Rad) * SpawnRadius;
                        float y = Mathf.Sin(angle * Mathf.Deg2Rad) * SpawnRadius;
                        Vector3 spawnPoint = transform.position + new Vector3(x, y, 0f);
                        SpawnInstance(spawnPoint, NumberOfSpawnPoints);
                        float rotationAngle = angle;
                        spawnedInstance.transform.rotation = Quaternion.Euler(0f, 0f, rotationAngle);
                    }
                }

            }
        }

        private void SpawnInstance(Vector3 SpawnPoint, int numberofspawnpoints)
        {

            spawnedInstance = Instantiate(Spawned, SpawnPoint, Quaternion.identity);
            spawnedInstance.GetComponent<Spawnable>().objective = (Spawnable.Objective)SpawnedObjective;
            spawnedInstance.GetComponent<Spawnable>().Speed = SpawnedSpeed;
            spawnedInstance.GetComponent<Spawnable>().DamagePower = DamagePower;
            spawnedInstance.GetComponent<Spawnable>().DurationOfLife = SpawnedLife;
            spawnedInstance.transform.rotation = transform.rotation;
            Transform firstChildTransform = spawnedInstance.transform.GetChild(0);
            // Rotate the first child based on EnemyRotation
            if (ProjectileRotationtype == ProjectileRotationType.Absolute)
            {
                firstChildTransform.rotation = Quaternion.Euler(0f, 0f, SpawnedRotation);
            }
            else
            {
                firstChildTransform.rotation = Quaternion.Euler(0f, 0f, SpawnedRotation +transform.rotation.z);
            }
        }
    }
}
