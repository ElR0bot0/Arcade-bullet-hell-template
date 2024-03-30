using Assets.Scripts.General;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletSpawner : Spawner
{
    public bool isFiring = false;
    public override void Update()
    {
        if (isFiring)
        {
            base.Update();
        }
    }
}
