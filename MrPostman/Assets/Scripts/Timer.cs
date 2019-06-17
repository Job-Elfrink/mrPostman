using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    Image timerbar;
    public float maxTime = 10f;
    float timeLeft;

    public GameObject gameOver;
    
    void Start()
    {
        gameOver.SetActive(false);
        timerbar = GetComponent<Image>();
        timeLeft = maxTime;
    }


    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timerbar.fillAmount = timeLeft / maxTime;
        }
        else
        {
            gameOver.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
