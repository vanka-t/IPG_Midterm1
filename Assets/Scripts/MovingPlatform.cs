using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingPlatform : MonoBehaviour
{
    CharacterController player;
    Vector3 oldPos;

 

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            //player moved w platform
            player.Move(transform.position - oldPos);
            oldPos = transform.position;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.GetComponent<CharacterController>();
            oldPos = transform.position;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //if player gets off, it doesnt move with the platform anymore
            player = null;
        }
    }
}
