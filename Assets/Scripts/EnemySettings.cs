using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySettings : MonoBehaviour
{
   
    protected Transform target;
    
 
  


    //current health
    protected float hp = 0;
    //Total health
    [SerializeField]
    protected float hpTotal = 100;
    private float timer = 0f;
    [SerializeField]
    private float timerTotal = 1f;


    //SHOOT
    //[SerializeField]
    private float bulletTimer = 5; //timer to shoot at player
    public float enemySpeed;//
    private float bulletTime;

    public GameObject enemyBullet;
    public Transform spawnPoint;

    protected NavMeshAgent nav;

    //NavMeshHit closestHit;
 



// Start is called before the first frame update
protected virtual void Start() //protected virtual = enables overriding it in later scripts
    {
        hp = hpTotal;
        target = GameManager.instance.player;
        nav = GetComponent<NavMeshAgent>();

        //Temp
        //nav.SetDestination(Vector3.zero);



        //if (NavMesh.SamplePosition(gameObject.transform.position, out closestHit, 500f, NavMesh.AllAreas))
        //{
        //    gameObject.transform.position = closestHit.position;
        //}
           
        //else
        //{

        //    Debug.LogError("Couldn't find position on NavMesh!");
        //}



    }

    // Update is called once per frame
    protected virtual void Update()
    {
        TimerTool();
   
    }


    //basic manual timer
    private void TimerTool()
    {
        if(timer> timerTotal)
        {
            timer = 0;
            TimerContent();
        }
        else
        {
            timer += Time.deltaTime;
        }

    }


    protected virtual void TimerContent()
    {
        //times up

    }


    public virtual void Damaged(float damage)
    {
        hp = Mathf.Max(0, hp - damage);
        if(hp == 0)
        {
            Death();
        }
    }

    protected virtual void Death()
    {
        SpawnerManager.instance.RemoveEnemy(this);
        Destroy(gameObject);
    }

    protected virtual void ShootAtPlayer()
    {
        bulletTime -= Time.deltaTime;

        if (bulletTime > 0) return;

        bulletTime = bulletTimer;

        //spawning bullets from  enemySpawnPoint
        GameObject bulletObj = Instantiate(enemyBullet, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
        Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();
        bulletRig.AddForce(bulletRig.transform.forward * enemySpeed);
        Destroy(bulletObj, 0.1f);



    }
}
