using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDownTimer : MonoBehaviour
{
    public TMP_Text timeup;
    public TMP_Text gameOverText;
    public Button restart;
    public static CountDownTimer instance;
    public TMP_Text countDown;
    public float timer;
    public bool istimerStart;
    public bool istimeUp;
    // Start is called before the first frame update
    private void Awake()
    {
        gameOverText.gameObject.SetActive(false);
        restart.gameObject.SetActive(false);
        timeup.gameObject.SetActive(false);
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (istimerStart)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                upgradetime(timer);
            }
            else
            {
                timeup.gameObject.SetActive(true);
                restart.gameObject.SetActive(true);
                timer = 0;
                istimerStart = false;
                istimeUp = true;
            }
        }


    }
    void upgradetime(float currenttime)
    {
        currenttime += 1;
        float min = Mathf.FloorToInt(currenttime / 60);
        float sec = Mathf.FloorToInt(currenttime % 60);
        countDown.text = min + " : " + sec;
    }
}
