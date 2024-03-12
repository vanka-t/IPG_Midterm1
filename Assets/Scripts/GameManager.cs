using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //always add when dealing w multiple scenes
using VanessaMusic.Utilities;


public class GameManager : MonoBehaviour
{
    
    public static GameManager instance;
    public Transform player;

    [HideInInspector]
    public bool isGameOver = false;
   // public bool nextLevel = false;
    public bool isLevelComplete = false;
    //public bool level2 = false;

    // [SerializeField]
    // AudioClip bgMusic;

    [SerializeField]
    public GameObject gameOverPage;
    public GameObject youWinPage;

    public GameObject playerObj;
    public GameObject healthBar;




    
   // public int levelCount = 0;


    //background music
    public AudioSource Source;
    public AudioClip menuMusic, level1Music, level2Music, gameOverMusic;

    private string currentScene;

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

      Source = GetComponent<AudioSource>();
       


    }

     public void Update()
    {
        BackgroundMusic();
        if (!Source.isPlaying)
        {
            Source.Play();
        }

    }

    //changing music depending on scene
    public void BackgroundMusic()
    {
      

        currentScene = SceneManager.GetActiveScene().name;

        
        switch (currentScene)
        {
            //menu music
            case "MainMenu":
                Source.clip = menuMusic;
                break;
           //lvl 1
            case "GameScene":
                Source.clip = isGameOver ? gameOverMusic : level1Music;
                break;
            //lvl 2
            case "Level3":
                Source.clip = isGameOver ? gameOverMusic : level2Music;
                break;
            //lvl 3
            case "Level2a":
                Source.clip = isGameOver ? gameOverMusic : level1Music;
                break;
             //final Winning page


        }

        }
    public void GameOver()
    {
        //games over
        isGameOver = true;
        Source.clip = menuMusic;

        gameOverPage.SetActive(true); //display gameover UI

        
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }


    public void LevelComplete()
    {
        print("WIIIIIIINNNNN");
       isLevelComplete = true;
        Source.Pause();
        youWinPage.SetActive(true); //display gameover UI
        //NextLevel();
       

        //levelComplete = false;

    }


    public void NextLevel()
    {
        //DontDestroyOnLoad(this);
        //DontDestroyOnLoad(playerObj);
        //DontDestroyOnLoad(healthBar);
        isLevelComplete = false;
        youWinPage.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // go to next scene/level
        
        //playerObj.transform.position = new Vector3(0, 0, 0);
      




    }
}
