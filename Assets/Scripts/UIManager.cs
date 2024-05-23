using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Canvas WinCanvas;

    public void Start()
    {
        WinCanvas.enabled = false;
    }

    public void OnWin()
    {
        WinCanvas.enabled = true;
    }
    public void OnExit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void OnPlayAgain()
    { 
        SceneManager.LoadScene("SampleScene");
        WinCanvas.enabled = false;
    }
}
