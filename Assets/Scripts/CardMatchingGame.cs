
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardMatchingGame : MonoBehaviour
{
    public Button[] buttons;
    public Sprite[] images; // Assign these from the Inspector
    private List<Sprite> gameImages = new List<Sprite>();
    private List<int> pickedIndices = new List<int>();
    private Button firstGuess, secondGuess;
    private int firstGuessIndex, secondGuessIndex;
    private bool firstGuessMade = false;
    public Sprite queMark;
    public UIManager manager;
    public GameObject gridLayoutGroupObject;

    void Start()
    {
        GetButtons();
        AddListeners();
        AddImages();
        Shuffle(gameImages);
        InitializeButtons();
    }

    void GetButtons()
    {
        //buttons = GameObject.FindObjectsOfType<Button>();
        buttons = gridLayoutGroupObject.GetComponentsInChildren<Button>();

        foreach (Button button in buttons)
        {
            ResetButtonColors(button);
        }
    }

    void ResetButtonColors(Button button)
    {
        ColorBlock cb = button.colors;
        cb.normalColor = Color.white;
        cb.highlightedColor = Color.white;
        cb.pressedColor = Color.white;
        cb.selectedColor = Color.white;
        cb.disabledColor = Color.white;
        button.colors = cb;
    }

    void AddListeners()
    {
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => PickButton());
        }
    }

    void AddImages()
    {
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < images.Length; j++)
            {
                gameImages.Add(images[j]);
            }
        }
    }

    void InitializeButtons()
    {
        foreach (Button button in buttons)
        {
            button.image.sprite = queMark;
        }
    }

    void PickButton()
    {
        if (firstGuess && secondGuess)
            return;

        Button clickedButton = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Button>();

        int buttonIndex = System.Array.IndexOf(buttons, clickedButton);
        clickedButton.interactable= false;

        if (!pickedIndices.Contains(buttonIndex))
        {
            StartCoroutine(FlipCard(clickedButton, gameImages[buttonIndex]));

            if (!firstGuessMade)
            {
                firstGuess = clickedButton;
                firstGuessIndex = buttonIndex;
                firstGuessMade = true;
            }
            else
            {
                secondGuess = clickedButton;
                secondGuessIndex = buttonIndex;
                StartCoroutine(CheckMatch());
            }
        }
    }

    IEnumerator CheckMatch()
    {
        yield return new WaitForSeconds(1);

        if (gameImages[firstGuessIndex] == gameImages[secondGuessIndex])
        {
            Debug.Log("Match Found!");
            pickedIndices.Add(firstGuessIndex);
            pickedIndices.Add(secondGuessIndex);

            // Check if all pairs have been matched
            if (pickedIndices.Count == buttons.Length)
            {
                manager.OnWin();
                Debug.Log("Congratulations! You've matched all the pairs and won the game!");
            }
        }
        else
        {
            StartCoroutine(FlipCard(firstGuess, queMark));
            StartCoroutine(FlipCard(secondGuess, queMark));

            firstGuess.interactable = true;
            secondGuess.interactable = true;
        }

        firstGuess = null;
        secondGuess = null;
        firstGuessMade = false;
    }

    IEnumerator FlipCard(Button button, Sprite newImage)
    {
        float duration = 0.3f; // Duration of the flip
        float halfway = duration / 2; // Halfway point

        // Scale down to 0
        for (float t = 0; t < halfway; t += Time.deltaTime)
        {
            button.transform.localScale = new Vector3(1 - (t / halfway), 1, 1);
            yield return null;
        }

        // Set the new image
        button.image.sprite = newImage;

        // Scale back up to 1
        for (float t = 0; t < halfway; t += Time.deltaTime)
        {
            button.transform.localScale = new Vector3(t / halfway, 1, 1);
            yield return null;
        }

        // Ensure the scale is set to 1 after the flip
        button.transform.localScale = Vector3.one;
    }

    void Shuffle(List<Sprite> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int rnd = Random.Range(0, i);
            Sprite temp = list[i];
            list[i] = list[rnd];
            list[rnd] = temp;
        }
    }
}

