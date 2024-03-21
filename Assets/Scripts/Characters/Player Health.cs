using System.Collections;
using System.Collections.Generic;
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
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public float Health
    {
        set
        {
            health = value;
            if (health <= 0)
            {
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
    }

    private void Update()
    {
        if(health > maxHealth)
        {
            health = maxHealth;
        }
        for (int i = 0; i < Containers.Length; i++)
        {
            if(i < health)
            {
                Object fill = Containers[i].transform.GetChild(0);
                fill.GameObject().SetActive(true);
            }else
            {
                Object fill = Containers[i].transform.GetChild(0);
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
