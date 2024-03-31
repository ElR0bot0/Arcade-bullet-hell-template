using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


namespace Assets.Scripts.General
{
    internal class Stopper : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag("PowerUp"))
            {
                if (other.CompareTag("Spawner"))
                {
                    other.GetComponent<EnemySpawner>().IsStopped = true;
                }
                else
                {
                    if (other.gameObject.transform.parent.gameObject != null)
                    {

                        var EnemyShipFatherObject = other.gameObject.transform.parent.gameObject;
                        if (EnemyShipFatherObject.CompareTag("Enemy"))
                        {
                            if (EnemyShipFatherObject.GetComponent<EnemyShip>().stoppingPoint == this.gameObject)
                            {
                                EnemyShipFatherObject.GetComponent<EnemyShip>().IsStopped = true;
                            }
                        }
                    }
                }
            }
            
            
        }
    }
}
