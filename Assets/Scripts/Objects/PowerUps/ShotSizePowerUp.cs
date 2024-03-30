using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Objects.PowerUps
{
    internal class ShotSizePowerUp : PowerUp
    {
        public override void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                var PlayerBulletSize = other.gameObject.transform.GetChild(0).gameObject.GetComponent<PlayerBulletSpawner>().Size;
                other.gameObject.transform.GetChild(0).gameObject.GetComponent<PlayerBulletSpawner>().Size = PlayerBulletSize + 0.5f;
            }
            base.OnTriggerEnter2D(other);
        }
    }
}
