using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //always add when dealing w multiple scenes
using VanessaMusic.Utilities; 

public class MenuManager : MonoBehaviour
{

    

    [SerializeField]
    AudioClip bgMusic;
    public AudioClip bgMusic2;
    [SerializeField]
    AudioClip buttonSound;

    public Scene scene11;
    public string scene1, scene2;


     string currentScene;

    // Start is called before the first frame update
    private void Start()
    {
         MusicManager.instance.SwitchMusic(bgMusic2);

    }
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        BackgroundMusic();
    }

    void BackgroundMusic()
    {
        currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "GameScene")
        {

            MusicManager.instance.SwitchMusic(bgMusic);
            //MusicManager.instance.SwitchMusic(bgMusic1);

        }
        else 
        {
            //print(currentScene);
            MusicManager.instance.SwitchMusic(bgMusic2);
   

        
            print("oh" + currentScene);

        }

    }

    public void StartGame()
        {
            AudioSource.PlayClipAtPoint(buttonSound, transform.position, 1);

            SceneManager.LoadScene("GameScene");
        }

    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene");

        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
