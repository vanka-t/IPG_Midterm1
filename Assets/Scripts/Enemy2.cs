using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : EnemySettings
{
    //SHOOT
    //[SerializeField]
    private float bulletTimer = 5; //timer to shoot at player
    public float enemySpeed;//
    private float bulletTime;

    //public GameObject enemyBullet;
    public Transform spawnBulletPoint;



    protected void Update()
    {
        base.Update(); //inheriting enemySettings
        ShootAtPlayer();

    }

    protected override void TimerContent()
    {
        
        //recover hp over time
        hp = Mathf.Min(hp + Time.deltaTime, hpTotal);
        nav.SetDestination(target.position); //chase player
    }

    void ShootAtPlayer()
    {
        bulletTime -= Time.deltaTime;

        if (bulletTime > 0) return;

        bulletTime = bulletTimer;

        //spawning bullets from  enemySpawnPoint
        GameObject bulletObj = Instantiate(enemyBullet, spawnBulletPoint.transform.position, spawnBulletPoint.transform.rotation) as GameObject;
        Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();
        bulletRig.AddForce(bulletRig.transform.forward * enemySpeed);
        Destroy(bulletObj, 0.1f);



    }

}
