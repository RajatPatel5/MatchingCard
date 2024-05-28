
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<GameObject> levelPrefabs; // Assign these from the Inspector
    private int currentLevelIndex = 0;
    private GameObject currentLevelInstance;
    [SerializeField] private Transform canvasParent;

    void Start()
    {
        if (levelPrefabs.Count > 0)
        {
            LoadLevel(currentLevelIndex);
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
            LoadLevel(currentLevelIndex);
        }
        else
        {
            Debug.Log("No more levels to load.");
        }
    }



    public void RestartCurrentLevel()
    {
        LoadLevel(currentLevelIndex);
    }

    private void LoadLevel(int levelIndex)
    {
        if (currentLevelInstance != null)
        {
            Destroy(currentLevelInstance);
        }

        if (levelIndex >= 0 && levelIndex < levelPrefabs.Count)
        {
            currentLevelInstance = Instantiate(levelPrefabs[levelIndex], canvasParent);
            UIManager.Instance.game = currentLevelInstance.GetComponent<CardMatchingGame>();
        }
        
    }
}


