using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UIElements.Image;

public class PlayerHealth : MonoBehaviour
{
    //Declaracion para manejar la vida
    public float health;
    public float maxHealth;
    public GameObject[] Containers;
    Animator animator;
    MenuManager Menumanager;
    PlayerController playerController;
    void Start()
    {
        animator = GetComponent<Animator>();
        Menumanager = FindObjectOfType<MenuManager>();
        playerController = GetComponent<PlayerController>();
    }
    public float Health
    {
        set
        {
            health = value;
            if (health <= 0)
            {
                playerController.enabled = false;
                animator.SetBool("Dead", true);
            }
        }

        get
        {
            return health;
        }
    }

    public void Dies()
    {
        Destroy(gameObject);
        Menumanager.DeadScreen();
    }
    
    private void Update()
    {
        if(health > maxHealth)
        {
            health = maxHealth;
        }
        for (int i = 0; i < Containers.Length; i++)
        {
            Object fill = Containers[i].transform.GetChild(0);
            if (i < health)
            {
                fill.GameObject().SetActive(true);
            }else
            {
                fill.GameObject().SetActive(false);
            }

            if(i < maxHealth)
            {
                Containers[i].SetActive(true);
            }
            else
            {
                Containers[i].SetActive(false);
            }
        }
    }
}
