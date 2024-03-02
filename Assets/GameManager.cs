using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


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

     void Update()
    {
        if (isGameOver)
        {
            print("yippeee");
            SceneManager.LoadScene("GameOverScene");

        }

    }

    public void GameOver()
    {
        //games over
     //  isGameOver = true;

    
        //gameOverPage.SetActive(true); //display gameover UI
        
    }
}
