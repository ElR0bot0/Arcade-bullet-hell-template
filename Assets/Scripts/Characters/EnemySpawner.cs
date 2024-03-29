using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.General;
using Unity.VisualScripting;

public class EnemySpawner : Spawner
{
    [Header("Activation attributes")]
    public float StartTime = 0f;
    public float EndTime = 0f;

    private float time = 0f;
    public override void Update()
    {
        time += Time.deltaTime;
        if(time > StartTime && time < EndTime)
        {
            base.Update();
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
