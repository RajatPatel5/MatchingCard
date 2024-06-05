using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public Canvas StartCanvas;
    public Canvas MainCanvas;
    public Canvas PlayCanvas;
    public Canvas WinCanvas;
    public Canvas GameOverCanvas;
    public Canvas PlayButtonCanvas;


    public LevelManager levelManager;
    public Button nextButton;
    public Button pauseButton;
    public Button playButton;
    public Image image1;
    public Image image2;
    public CardMatchingGame game;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    public void Start()
    {
        StartCanvas.enabled = true;
        WinCanvas.enabled = false;
        GameOverCanvas.enabled = false;
        MainCanvas.enabled = false;
        PlayCanvas.enabled = false;
        pauseButton.enabled = true;
        PlayButtonCanvas.enabled = false;
    }

    public void OnPlayGame()
    {
        Timer.instance.ResetTimer();
        PlayButtonCanvas.enabled=false;
        MainCanvas.enabled = true;
        PlayCanvas.enabled = true;
      
    }
    public void OnWin()
    {
        WinCanvas.enabled = true;
        Timer.instance.StopTimer();
       
    }
    public void OnGameOver()
    {
        GameOverCanvas.enabled = true;
        Timer.instance.StopTimer();
      
    }
    public void OnPause()
    {
        image1.enabled = false;
        Timer.instance.StopTimer();
        game.SetButtons(false);
    }
    public void OnPlay()
    {
        image1.enabled = true;
        Timer.instance.StartTimer();
        game.SetButtons(true);
    }
    public void OnExit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void OnPlayAgain()
    {
        levelManager.RestartCurrentLevel();
        WinCanvas.enabled = false;
        GameOverCanvas.enabled = false;
        Timer.instance.ResetTimer();
        Timer.instance.StartTimer();
    }

    public void OnNext()
    {
        WinCanvas.enabled = false; 
        Timer.instance.ResetTimer();
        Timer.instance.StartTimer();
        levelManager.LoadNextLevel();
    }
   
}


