using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : EnemySettings
{
    //SHOOT
   


    

    protected override void TimerContent()
    {
        
        //recover hp over time
        hp = Mathf.Min(hp + Time.deltaTime, hpTotal);
        nav.SetDestination(target.position); //chase player
    }

    //void ShootAtPlayer()
    //{
    //    thisBulletTime -= Time.deltaTime;

    //    if (thisBulletTime > 0) return;

    //    thisBulletTime = thisBulletTimer;

    //    //spawning bullets from  enemySpawnPoint
    //    GameObject bulletObj = Instantiate(enemyBullet, spawnBulletPoint.transform.position, spawnBulletPoint.transform.rotation) as GameObject;
    //    Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();
    //    bulletRig.AddForce(bulletRig.transform.forward * enemySpeed);
    //    print("shooting!");
    //   // Destroy(bulletObj, 0.1f);



    //}

}
