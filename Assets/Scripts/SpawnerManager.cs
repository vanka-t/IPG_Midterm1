using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//SINGLETON
public class SpawnerManager : MonoBehaviour
{
    public static SpawnerManager instance;

    public GameObject[] prefab_Bullets;
    public EnemySettings[] prefab_Enemies;

    private void Awake()
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
