using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Objects.PowerUps
{
    internal class FireRatePowerUp : PowerUp
    {
        public override void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                var PlayerFireRate = other.gameObject.transform.GetChild(0).gameObject.GetComponent<PlayerBulletSpawner>().FiringRate;
                other.gameObject.transform.GetChild(0).gameObject.GetComponent<PlayerBulletSpawner>().FiringRate = PlayerFireRate* 0.75f;
            }
            base.OnTriggerEnter2D(other);
        }
    }
}
