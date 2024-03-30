using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Objects.PowerUps
{
    internal class PowerUp : MonoBehaviour
    {
        public virtual void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("si se encuentra");
            if (other.gameObject.CompareTag("Player"))
            {
                Destroy(this.gameObject);
            }
        }
    }
}
