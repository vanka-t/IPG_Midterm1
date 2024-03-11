using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

//SINGLETON
public class SpawnerManager : MonoBehaviour
{
    public static SpawnerManager instance;

    //adds list/array to component on inspector
   // public EnemyBullet prefab_EnemyBullets;
    public Bullet prefab_Bullets;
    public EnemySettings[] prefab_Enemies;

    List<Bullet> bulletList = new List<Bullet>();
    List<EnemySettings> enemyList = new List<EnemySettings>();


    [SerializeField]
    Transform bulletGroup;


    [SerializeField]
    Transform enemyZones;
    [SerializeField]
    Transform[] spawnPoints;
    [SerializeField]
    LayerMask playerLayerMask;


  




    //Spawning mechanics



    struct SpawnRate
    {
        public float spawnRate_Enemy1;
        public float spawnRate_Enemy2;
        public float spawnRate_Enemy3;

        //constructor
        public SpawnRate(int currentLevel)
        {
            //changing spawning rate according to difficulty of round
            if (currentLevel == 1)
            {
                spawnRate_Enemy1 = 0.003f;
                spawnRate_Enemy2 = 0.002f;
                spawnRate_Enemy3 = 0.001f;
            } else if (currentLevel == 2)
            {
                spawnRate_Enemy1 = 0.09f;
                spawnRate_Enemy2 = 0.08f;
                spawnRate_Enemy3 = 0.07f;
            }
            else
            {
                spawnRate_Enemy1 = 0.03f;
                spawnRate_Enemy2 = 0.02f;
                spawnRate_Enemy3 = 0.01f;
            }

        }
    }

    SpawnRate currentSpawnRate = new SpawnRate(1);


     void Awake()
    {
        //same as music manager
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    private void Update()
    {
        
        //var random_val = Random.value;
        if (Random.value < currentSpawnRate.spawnRate_Enemy1)
        {
            //(old code)
            //var enemy = Instantiate(prefab_Enemies[0], enemyZones);
            //enemy.transform.position = FindAvailableSpawnPoint().position;
            Transform spawnPoint = FindAvailableSpawnPoint();
            if (spawnPoint != null)
            {
                //Spawn Enemy LV 1
                SpawnEnemies(0, spawnPoint.position, spawnPoint.rotation);
            }

            

            

        } else if (Random.value < currentSpawnRate.spawnRate_Enemy2)
        {
            Transform spawnPoint = FindAvailableSpawnPoint();
            if (spawnPoint != null)
            {
                //Spawn Enemy LV 2
                SpawnEnemies(1, spawnPoint.position, spawnPoint.rotation);
            }
        }
        else if (Random.value < currentSpawnRate.spawnRate_Enemy3)
        {
            Transform spawnPoint = FindAvailableSpawnPoint();
   
            if (spawnPoint != null)
            {
                //Spawn Enemy LV 3
                SpawnEnemies(2, spawnPoint.position, spawnPoint.rotation);
            }
        }
    }

    private Transform FindAvailableSpawnPoint()
    {
        //create an available list of spawnpoints
        //if player is nearby, temporarily disable it
        List<Transform> availableSpawnPoints = new List<Transform>();
        //when calling, it returns the random spaw point chosen
        foreach(Transform sP in spawnPoints)
        {
            Collider[] hitColliders = Physics.OverlapSphere( //creates an invisible sphere collider
                sP.position,
                30, //change?
                playerLayerMask
                );

            if (hitColliders.Length == 0)
            {
                //no player nearby
                availableSpawnPoints.Add(sP);
            }
        }



        if (availableSpawnPoints.Count == 0)
        {
            return null;
        }

        //if theres available spawnPoints --> return a random one
        return availableSpawnPoints[Random.Range(0, availableSpawnPoints.Count)];


        //  return spawnPoints[Random.Range(0, spawnPoints.Length)];
    }

    //generating bullets
    public void SpawnBullet(Vector3 pos, Quaternion rot)
    {
        Bullet bullet = Instantiate(prefab_Bullets, bulletGroup); //change
        bullet.transform.position = pos;
        bullet.transform.rotation = rot;

        bulletList.Add(bullet);

    }
    public void RemoveBullet(Bullet bullet)
    {
        bulletList.Remove(bullet);
    }

    //generating enemies
    public void SpawnEnemies(int id, Vector3 pos, Quaternion rot)
    {
        EnemySettings enemy = Instantiate(prefab_Enemies[id], enemyZones);
        enemy.transform.position = pos;
        enemy.transform.rotation = rot;

        enemyList.Add(enemy);
    }



    public void RemoveEnemy(EnemySettings enemy)
    {
        if(enemy as Enemy1)
        {
            currentSpawnRate.spawnRate_Enemy1 += 0.0001f;

        } else if (enemy as Enemy2)
        {
            currentSpawnRate.spawnRate_Enemy2 += 0.0001f;

        } else if (enemy as Enemy3)
        {
            currentSpawnRate.spawnRate_Enemy3 += 0.0001f;

        }

        enemyList.Remove(enemy);


    }

   
}
