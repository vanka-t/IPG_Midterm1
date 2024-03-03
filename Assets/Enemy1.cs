using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : EnemySettings
{
    protected override void Start()
    {
        base.Start();
        nav.speed *= 3;
    }
    protected override void Damaged(float damage)
    {
        //overriden so that damage taken has double the impact on hp
        hp = Mathf.Max(0, hp - damage * 2); 
        if(hp == 0)
        {
            Death();
        }
    }
}
