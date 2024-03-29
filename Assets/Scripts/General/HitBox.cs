using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.General
{
    public class HitBox : MonoBehaviour
    {

        private string[] Objectivelist = { "None", "All", "Enemy", "Player" };
        public enum Objective : int { None = 0, All = 1, Player = 2, Enemy = 3 }
        [HideInInspector] public Objective objective;
        [HideInInspector] public float DamagePower = 1;
        [HideInInspector] public int PointsValueOnKill = 0;
        GameObject parentSpawnableObject;

        private void Start()
        {
            parentSpawnableObject = gameObject.transform.parent.gameObject;
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (objective != Objective.None)
            {
                if (other.gameObject.transform.parent != null)
                {
                    // Get the parent GameObject of the collided object
                    GameObject parentObject = other.gameObject.transform.parent.gameObject;

                    // Try to get the component from the parent GameObject
                    if (parentObject.TryGetComponent<EnemyShip>(out var enemy) && (objective == Objective.Enemy || objective == Objective.All))
                    {
                        enemy.Health -= DamagePower;
                        Destroy(parentSpawnableObject);
                    }
                }
                if (other.TryGetComponent<PlayerHealth>(out var player) && objective == Objective.Player || objective == Objective.All)
                {
                    player.Health -= DamagePower;
                    Destroy(parentSpawnableObject);
                }
            }
        }
        public void Dies()
        {
            FindObjectOfType<GameManager>().ScoreUpdate(PointsValueOnKill);
            Destroy(parentSpawnableObject);
        }
    }
}
