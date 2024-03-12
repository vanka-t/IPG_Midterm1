using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement; //always add when dealing w multiple scenes

//SINGLETON
public class SpawnerManager : MonoBehaviour
{
    public static SpawnerManager instance;


    public int currentLevelInput;

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



    // Struct to define spawn rates based on level
    struct SpawnRate
    {
        public float spawnRate_Enemy1;
        public float spawnRate_Enemy2;
        public float spawnRate_Enemy3;

        // Constructor
        public SpawnRate(int currentLevel)
        {
            
            if (currentLevel == 1)
            {
                // For level 1, only spawn Enemy2
                spawnRate_Enemy1 = 0f;
                spawnRate_Enemy2 = 0.006f;
                spawnRate_Enemy3 = 0f;
            }
            else if (currentLevel == 2)
            {
                // For level 2, only spawn Enemy1
                spawnRate_Enemy1 = 0.09f;
                spawnRate_Enemy2 = 0f;
                spawnRate_Enemy3 = 0f;
            }
            else
            {
                // For level 3, spawn both Enemy1 and Enemy2
                spawnRate_Enemy1 = 0.003f;
                spawnRate_Enemy2 = 0.005f;
                spawnRate_Enemy3 = 0f;
            }
        }
    }


    SpawnRate currentSpawnRate;

    void Awake()
    {
     
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // Set currentSpawnRate based on GameManager's sceneIndex
       // int currentLevel = GameManager.instance.sceneIndex; 
        currentSpawnRate = new SpawnRate(currentLevelInput);
    }

    // Update is called once per frame
    private void Update()
    {
        // Spawn enemies based on random values and spawn rates
        if (Random.value < currentSpawnRate.spawnRate_Enemy1)
        {
            Transform spawnPoint = FindAvailableSpawnPoint();
            if (spawnPoint != null)
            {
                // Spawn Enemy LV 1
                SpawnEnemies(0, spawnPoint.position, spawnPoint.rotation);
            }
        }
        else if (Random.value < currentSpawnRate.spawnRate_Enemy2)
        {
            Transform spawnPoint = FindAvailableSpawnPoint();
            if (spawnPoint != null)
            {
                // Spawn Enemy LV 2
                SpawnEnemies(1, spawnPoint.position, spawnPoint.rotation);
            }
        }
        else if (Random.value < currentSpawnRate.spawnRate_Enemy3)
        {
            Transform spawnPoint = FindAvailableSpawnPoint();
            if (spawnPoint != null)
            {
                // Spawn Enemy LV 3
                SpawnEnemies(2, spawnPoint.position, spawnPoint.rotation);
            }
        }
    }

    private Transform FindAvailableSpawnPoint()
    {
  
        List<Transform> availableSpawnPoints = new List<Transform>();
        foreach (Transform sP in spawnPoints)
        {
            Collider[] hitColliders = Physics.OverlapSphere(
                sP.position,
                30, // Change ?
                playerLayerMask
            );

            if (hitColliders.Length == 0)
            {
                // No player nearby
                availableSpawnPoints.Add(sP);
            }
        }

        if (availableSpawnPoints.Count == 0)
        {
            return null;
        }

        // Return a random available spawn point
        return availableSpawnPoints[Random.Range(0, availableSpawnPoints.Count)];
    }


    public void SpawnBullet(Vector3 pos, Quaternion rot)
    {
        Bullet bullet = Instantiate(prefab_Bullets, bulletGroup);
        bullet.transform.position = pos;
        bullet.transform.rotation = rot;
        bulletList.Add(bullet);
    }

 
    public void RemoveBullet(Bullet bullet)
    {
        bulletList.Remove(bullet);
    }


    public void SpawnEnemies(int id, Vector3 pos, Quaternion rot)
    {
        EnemySettings enemy = Instantiate(prefab_Enemies[id], enemyZones);
        enemy.transform.position = pos;
        enemy.transform.rotation = rot;
        enemyList.Add(enemy);
    }

    // remove enemies
    public void RemoveEnemy(EnemySettings enemy)
    {
        if (enemy as Enemy1)
        {
            currentSpawnRate.spawnRate_Enemy1 += 0.0006f;
        }
        else if (enemy as Enemy2)
        {
            currentSpawnRate.spawnRate_Enemy2 += 0.0007f;
        }
        else if (enemy as Enemy3)
        {
            currentSpawnRate.spawnRate_Enemy3 += 0.0009f;
        }

        enemyList.Remove(enemy);
    }

}
