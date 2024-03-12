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




    
    public int levelCount = 0;



    public AudioSource Source;
    public AudioClip menuMusic;
    public AudioClip level1Music;
    public AudioClip level2Music, gameOverMusic;

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

        if (currentScene == "MainMenu")
        {
            
            Source.clip = menuMusic;

            //MusicManager.instance.SwitchMusic(menuMusic);

        }
        else if (currentScene == "GameScene")
        {
            // level 1 music
            // switch to "game over" music when dying
            Source.clip = isGameOver ? gameOverMusic :  level1Music;
     


        }
        else if (currentScene == "Level2a")
        {
            
            Source.clip = isGameOver ? gameOverMusic : level2Music;
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
