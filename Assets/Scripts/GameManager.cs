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


    AudioSource source;

    public AudioClip bgMusic1;

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

        source = GetComponent<AudioSource>();


    }

     void Update()
    {
        Scene sceneID = SceneManager.GetActiveScene();

        if (sceneID.name == "GameScene")
        {
            print("teehee");
            source.clip = bgMusic1;
            source.Play();

        } else
        {
            print("no teehee");

        }
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
       isLevelComplete = true;
        youWinPage.SetActive(true); //display gameover UI
        //NextLevel();
       

        //levelComplete = false;

    }


    public void NextLevel()
    {
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(playerObj);
        DontDestroyOnLoad(healthBar);
        isLevelComplete = false;
        youWinPage.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // go to next scene/level
        
        playerObj.transform.position = new Vector3(0, 0, 0);
      




    }
}
