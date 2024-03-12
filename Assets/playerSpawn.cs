using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSpawn : MonoBehaviour
{
    [SerializeField] private Vector3 startPos;

    private void Awake()
    {
        
        //set specific place where player will spawn for each level
        GameObject player = GameObject.FindWithTag("Player");
        player.transform.position = startPos;
        print("Good MORNING");
    }
}
