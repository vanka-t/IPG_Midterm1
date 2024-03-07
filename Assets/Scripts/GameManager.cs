using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

   

    public static GameManager instance;
    public Transform player;

    [HideInInspector]
    public bool isGameOver = false;
    public bool nextLevel = false;

   // [SerializeField]
   // AudioClip bgMusic;

    [SerializeField]
    public GameObject gameOverPage;

    




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

        
    }

     void Update()
    {
        //if (isGameOver)
        //{
        //    print("yippeee");
        //  //  SceneManager.LoadScene("GameOverScene");

        //}

    }

    public void GameOver()
    {
        //games over
        isGameOver = true;


        gameOverPage.SetActive(true); //display gameover UI

        
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void NextLevel()
    {
        //games over
        


        SceneManager.LoadScene("Level2");
        nextLevel = false;

    }
}
