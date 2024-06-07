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
    public Canvas PauseCanvas;
    public Canvas ExitCanvas;


    public LevelManager levelManager;
    public Button nextButton;
    public Button pauseButton;
    public Button playButton;
    public Image image1;
    public Image image2;
    public CardMatchingGame game;
    public Timer timer;

 
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
        PauseCanvas.enabled = false;
        ExitCanvas.enabled = false;
        timer.enabled = false;
    }

    public void OnPlayGame()
    {
        timer.enabled = true;
        game.InitializeTimer();
        Timer.instance.StartTimer();
       // int a=game.buttons.Length;
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
        PauseCanvas.enabled = true;
        image1.enabled = false;
        Timer.instance.StopTimer();
        game.SetButtons(false);
    }
    //public void OnPlay()
    //{
    //    image1.enabled = true;
    //    Timer.instance.StartTimer();
    //    game.SetButtons(true);
    //}
    public void OnExit()
    {
        ExitCanvas.enabled = true;
        PauseCanvas.enabled = false;
        WinCanvas.enabled = false;
        GameOverCanvas.enabled = false;
    }

    public void OnPlayAgain()
    {
        levelManager.RestartCurrentLevel();
        game.InitializeTimer();
        PauseCanvas.enabled = false;
        image1.enabled = true;
        WinCanvas.enabled = false;
        GameOverCanvas.enabled = false;
        Timer.instance.ResetTimer();
        Timer.instance.StartTimer();
        //ExitCanvas.enabled = false;
    }

    public void OnNext()
    {
        WinCanvas.enabled = false;
        game.InitializeTimer();
        Timer.instance.ResetTimer();
        Timer.instance.StartTimer();
        levelManager.LoadNextLevel();
    }

    public void OnResume()
    {
        PauseCanvas.enabled = false;
        image1.enabled = true;
        Timer.instance.StartTimer();
        game.SetButtons(true);
    }

    public void OnYes()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void OnNoExit()
    {
        GameOverCanvas.enabled = true;
        ExitCanvas.enabled = false;
    }

}


