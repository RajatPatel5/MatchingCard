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
    public void OnExit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void OnPlayAgain()
    {
        levelManager.RestartCurrentLevel();
      //  SceneManager.LoadScene("SampleScene");
        WinCanvas.enabled = false;
        GameOverCanvas.enabled = false;
        Timer.instance.ResetTimer();
        Timer.instance.StartTimer();

    }

    public void OnNext()
    {
       // nextButton.onClick.AddListener(levelManager.LoadNextLevel);
        WinCanvas.enabled = false; // Ensure the WinCanvas is disabled before loading the next level
        Timer.instance.ResetTimer();
        Timer.instance.StartTimer();
        levelManager.LoadNextLevel();

    }
}


