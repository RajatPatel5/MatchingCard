using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public Canvas WinCanvas;
    public Canvas GameOverCanvas;
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
            DontDestroyOnLoad(gameObject); // Keep this instance across scene loads
        }
        else
        {
            Destroy(gameObject); // Destroy any duplicate instances
        }
    }

    public void Start()
    {
        WinCanvas.enabled = false;
        GameOverCanvas.enabled = false;
        pauseButton.enabled = true;
    }

    public void OnWin()
    {
        WinCanvas.enabled = true;
        Timer.instance.StopTimer();
        //pauseButton.enabled = false;
    }
    public void OnGameOver()
    {
        GameOverCanvas.enabled = true;
        Timer.instance.StopTimer();
       // pauseButton.enabled = false;
    }
    public void OnPause()
    {
        image1.enabled = false;
        Timer.instance.StopTimer();
        game.SetButtonsInteractable(false);
    }
    public void OnPlay()
    {
        image1.enabled = true;
        Timer.instance.StartTimer();
        game.SetButtonsInteractable(true);
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


