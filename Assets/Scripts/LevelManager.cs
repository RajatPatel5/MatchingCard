
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    public List<GameObject> levelPrefabs;
    private int currentLevelIndex = 0;
    private GameObject currentLevelInstance;
    [SerializeField] private Transform canvasParent;
    public SpriteList spriteList;
    public Image image;
    public int initialAttempts = 15; 
    public TMP_Text attemptNoLabel;
    
    void Start()
    {
        if (levelPrefabs.Count > 0)
        {
            LoadLevel(currentLevelIndex, initialAttempts);
        }
        else
        {
            Debug.LogError("No level prefabs assigned to LevelManager.");
        }
    }
    public void LoadNextLevel()
    {
        if (currentLevelIndex < levelPrefabs.Count - 1)
        {
            currentLevelIndex++;
            int attemptsForNextLevel = initialAttempts - currentLevelIndex; // Decrease attempts by 1 for each level
            LoadLevel(currentLevelIndex, attemptsForNextLevel);
            image.sprite = spriteList.sprites[currentLevelIndex];
        }
        else
        {
            Debug.Log("No more levels to load.");
        }
    }
    public void RestartCurrentLevel()
    {
        LoadLevel(currentLevelIndex, initialAttempts - currentLevelIndex);
    }

    private void LoadLevel(int levelIndex , int attempts)
    {
        if (currentLevelInstance != null)
        {
            Destroy(currentLevelInstance);
        }

        if (levelIndex >= 0 && levelIndex < levelPrefabs.Count)
        {
            currentLevelInstance = Instantiate(levelPrefabs[levelIndex], canvasParent);
            CardMatchingGame game = currentLevelInstance.GetComponent<CardMatchingGame>();
            game.totalAttempts = attempts;
            game.attemptsLabel = attemptNoLabel;
         //   UIManager.Instance.game = game;
            UIManager.Instance.game = currentLevelInstance.GetComponent<CardMatchingGame>();
        }
        
    }
}


