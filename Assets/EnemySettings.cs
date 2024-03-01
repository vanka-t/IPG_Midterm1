using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySettings : MonoBehaviour
{
    NavMeshAgent nav;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();

        //Temp
        nav.SetDestination(Vector3.zero);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
