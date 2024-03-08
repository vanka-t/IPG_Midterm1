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
   // public bool nextLevel = false;
    public bool levelComplete = false;
    public bool level2 = false;

    // [SerializeField]
    // AudioClip bgMusic;

    [SerializeField]
    public GameObject gameOverPage;
    public GameObject youWinPage;

    public GameObject playerObj;




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


    public void LevelComplete()
    {
        print("WIIIIIIINNNNN");
       levelComplete = true;


        youWinPage.SetActive(true); //display gameover UI

       // levelComplete = false;

    }


    public void NextLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        DontDestroyOnLoad(playerObj);
        level2 = true;


    }
}
