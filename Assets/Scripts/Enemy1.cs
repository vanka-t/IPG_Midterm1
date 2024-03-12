using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy1 : EnemySettings
{


    protected override void TimerContent()
    {
        //recover health
        if (!nav.isOnNavMesh)
        {
            NavMeshHit hit;
            if (NavMesh.SamplePosition(transform.position, out hit, Mathf.Infinity, 1))
            {
                transform.position = hit.position;

                print("Found navmesh");
            }
            else
            {
                print("Couldn't find nav mesh");
                return;
            }
        };
        nav.SetDestination(target.position);
    }
    //protected override void Start()
    //{
    //    base.Start();
    //    nav.speed *= 3;
    //}
    public override void Damaged(float damage)
    {
        //overriden so that damage taken has double the impact on hp
        hp = Mathf.Max(0, hp - damage * 2); //.2f
        if(hp == 0)
        {
            Death();
        }
    }
}
