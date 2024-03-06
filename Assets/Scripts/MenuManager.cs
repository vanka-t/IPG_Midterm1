using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //always add when dealing w multiple scenes
using VanessaMusic.Utilities; 

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    AudioClip bgMusic;

    // Start is called before the first frame update
    private void Start()
    {
      //  MusicManager.instance.SwitchMusic(bgMusic);
        
    }

    
        public void StartGame()
        {
            SceneManager.LoadScene("GameScene");
        }

    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
