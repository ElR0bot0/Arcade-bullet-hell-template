using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.General.Triggers
{
    internal class EndLevel : MonoBehaviour
    {
        MenuManager Menumanager;
        GameManager Gamemanager;
        private void Start()
        {
            Menumanager= FindObjectOfType<MenuManager>();
            Gamemanager = FindObjectOfType<GameManager>();
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Gamemanager.ScoreUpdate(1000);
                Menumanager.EndLevel();
            }
        }
    }
}
