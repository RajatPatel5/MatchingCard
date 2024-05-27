//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class LevelManager : MonoBehaviour
//{

//    public List<GameObject> levelPrefabs; // Assign these from the Inspector
//    private int currentLevelIndex = 0;
//    private GameObject currentLevelInstance;
//    [SerializeField] private Transform canvasParent;
//    void Start()
//    {
//        if (levelPrefabs.Count > 0)
//        {
//            LoadLevel(currentLevelIndex);
//        }
//        else
//        {
//            Debug.LogError("No level prefabs assigned to LevelManager.");
//        }
//    }

//    public void LoadNextLevel()
//    {
//        if (currentLevelIndex < levelPrefabs.Count - 1)
//        {
//            currentLevelIndex++;
//            LoadLevel(currentLevelIndex);
//        }
//        else
//        {
//            Debug.Log("No more levels to load.");
//        }
//    }

//    public void LoadPreviousLevel()
//    {
//        if (currentLevelIndex > 0)
//        {
//            currentLevelIndex--;
//            LoadLevel(currentLevelIndex);
//        }
//        else
//        {
//            Debug.Log("This is the first level.");
//        }
//    }

//    public void RestartCurrentLevel()
//    {
//        LoadLevel(currentLevelIndex);
//    }

//    private void LoadLevel(int levelIndex)
//    {
//        if (currentLevelInstance != null)
//        {
//            Destroy(currentLevelInstance);
//        }

//        if (levelIndex >= 0 && levelIndex < levelPrefabs.Count)
//        {
//            currentLevelInstance = Instantiate(levelPrefabs[levelIndex], canvasParent);
//        }
//        else
//        {
//            Debug.LogError("Invalid level index.");
//        }
//    }
//}

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
            InitializeLevel(currentLevelInstance);
        }
        else
        {
            Debug.LogError("Invalid level index.");
        }
    }

    private void InitializeLevel(GameObject levelInstance)
    {
        CardMatchingGame game = levelInstance.GetComponent<CardMatchingGame>();
        if (game != null)
        {
            game.manager = UIManager.Instance; // Assign the UIManager instance
        }

    }
}


