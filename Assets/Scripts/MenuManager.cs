using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //always add when dealing w multiple scenes
using VanessaMusic.Utilities; 

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    AudioClip bgMusic;
    [SerializeField]
    AudioClip buttonSound;

    // Start is called before the first frame update
    private void Start()
    {
       MusicManager.instance.SwitchMusic(bgMusic);
        
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
