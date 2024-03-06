using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : EnemySettings
{
    protected override void TimerContent()
    {
        
        //recover hp over time
        hp = Mathf.Min(hp + Time.deltaTime, hpTotal);
        nav.SetDestination(target.position); //chase player
    }
}
