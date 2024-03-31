using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.General;
using Unity.VisualScripting;

public class EnemySpawner : Spawner
{
    [Header("Activation attributes")]
    public float EndTime = 0f;
    private float time = 0f;
    public GameObject stoppingPoint;
    [HideInInspector] public bool IsStopped = false;
    public override void Update()
    {
        if(stoppingPoint)
        {
            time += Time.deltaTime;
            if (time < EndTime)
            {
                base.Update();
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
    public override void Start()
    {
        base.Start();
        for(int i = 0; i < transform.childCount; i++) {
            var ChildDesabled = transform.GetChild(i).gameObject;
            ChildDesabled.SetActive(false);
        }
    }

}
