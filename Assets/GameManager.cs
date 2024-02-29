using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    public bool isGameOver = false;

    [SerializeField]
    AudioClip bgMusic;

    [SerializeField]
    GameObject gameOverPage;

    public Transform player;

    public static GameManager instance;




    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

    }

    public void GameOver()
    {
        //games over
        isGameOver = true;

        gameOverPage.SetActive(true); //display gameover UI
    }
}
