using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public AudioSource gameplay;
    public AudioClip fire;
    public AudioClip hit;
    public AudioClip explosion;
    public static GameManager instance;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        gameplay = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void playgameruntime()
    {
        Time.timeScale = 1;
    }
    public void pausegameruntime()
    {
        Time.timeScale = 0;
    }
    public void restartgame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void quitgame()
    {
        Application.Quit();
    }
    
}
