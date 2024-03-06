using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : EnemySettings
{
    bool secondLife = true;
    protected override void TimerContent()
    {
    
        nav.SetDestination(target.position); //chase player

    }

    protected override void Death()
    {
        //gets revived when killed the 1st time 
        if (secondLife)
        {
            secondLife = false;
            hp = hpTotal;
            nav.speed *= 2; //double the speed
        }
        else
        {
            SpawnerManager.instance.RemoveEnemy(this);//this line needs to be rewritten since the function overrides the original EnemySettings Death function
            //if killed upon 1 revival, it finally dies
            Destroy(gameObject);

        }
    }
}
