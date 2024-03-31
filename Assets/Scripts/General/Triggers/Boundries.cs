using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.General
{
    public class Boundries : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if(!other.gameObject.CompareTag("Player") && !other.gameObject.CompareTag("Untagged") && !other.gameObject.CompareTag("PowerUp"))
            {
                    if (other.gameObject.transform.parent.gameObject.CompareTag("Bullet"))
                    {
                        Destroy(other.gameObject.transform.parent.gameObject);
                    }
            }
                
        }
    }
}
