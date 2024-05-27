using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    
    public TMP_Text timerText;
    private float countdown = 30f;
    private bool timerRunning = true;
    public static Timer instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Optional: keep the timer across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        StartTimer();
        
    }


    void Update()
    {
        if (timerRunning)
        {
            countdown -= Time.deltaTime;
            DisplayTime(countdown);

            if (countdown <= 0f)
            {
                timerRunning = false;
                countdown = 0f;
                UIManager.Instance.OnGameOver();

                //UiManager.instance.SwitchScreen(GameScreens.GameOver);
                //SoundManager.inst.PlaySound(SoundName.GameOver);

            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void ResetTimer()
    {
        countdown = 30f;
        timerRunning = true;
    }

    public void StopTimer()
    {
        timerRunning = false;
    }

    public void StartTimer()
    {
        timerRunning = true;
    }
}



