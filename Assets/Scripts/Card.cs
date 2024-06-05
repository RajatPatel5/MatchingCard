//using System.Collections;
//using System.Collections.Generic;
//using System.Diagnostics.CodeAnalysis;
//using UnityEngine;
//using UnityEngine.Events;
//using UnityEngine.UI;

//public class Card : MonoBehaviour
//{
//    public Sprite frontImage;
//    public Sprite backImage;
//    private Button button;
//    private bool isFlipped = false;

//    public static event UnityAction<Card> OnCardClicked;

//    void Awake()
//    {
//        button = GetComponent<Button>();
//        button.onClick.AddListener(OnButtonClicked);
//    }

//    void OnButtonClicked()
//    {
//        if (isFlipped) return;

//        isFlipped = true;
//        StartCoroutine(FlipCard(frontImage));
//        OnCardClicked?.Invoke(this);
//    }

//    public void SetImage(Sprite image)
//    {
//        frontImage = image;
//    }

//    public void ResetCard()
//    {
//        isFlipped = false;
//        button.image.sprite = backImage;
//        //  StartCoroutine(FlipCard(backImage));
//        button.interactable = true;
//    }

//    public void DisableCard()
//    {
//        button.interactable = false;
//    }

//    IEnumerator FlipCard(Sprite newImage)
//    {
//        float duration = 0.3f;
//        float halfway = duration / 2;

//        for (float t = 0; t < halfway; t += Time.deltaTime)
//        {
//            button.transform.localScale = new Vector3(1 - (t / halfway), 1, 1);
//            yield return null;
//        }

//        button.image.sprite = newImage;

//        for (float t = 0; t < halfway; t += Time.deltaTime)
//        {
//            button.transform.localScale = new Vector3(t / halfway, 1, 1);
//            yield return null;
//        }

//        button.transform.localScale = Vector3.one;

//    }
//}

using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Card : MonoBehaviour
{
    public int Index { get; private set; }
    public Sprite Image { get; private set; }
    private Sprite questionMark;
    private Button button;
    private Image buttonImage;
    private bool isFlipped = false;

    public event UnityAction<Card> OnCardSelected;
    public void Initialize(int index, Sprite image, Sprite questionMarkSprite)
    {
        Index = index;
        Image = image;
        questionMark = questionMarkSprite;

        button = GetComponent<Button>();
        buttonImage = GetComponent<Image>();

        button.onClick.AddListener(OnCardClicked);
        FlipBack();
    }

    private void OnCardClicked()
    {
        if (isFlipped) return;

        Flip();
        OnCardSelected?.Invoke(this);
    }

    public void Flip()
    {
        if (isFlipped) return;

        StartCoroutine(FlipCard(Image));
        isFlipped = true;
    }

    public void FlipBack()
    {
        if (!isFlipped) return;

        StartCoroutine(FlipCard(questionMark));
        isFlipped = false;
    }
    public void Remove()
    {
        StartCoroutine(RemoveCard());
    }
    IEnumerator FlipCard(Sprite newImage)
    {
        float duration = 0.2f; // Duration of the flip
        float halfway = duration / 2; // Halfway point

        // Scale down to 0
        for (float t = 0; t < halfway; t += Time.deltaTime)
        {
            transform.localScale = new Vector3(1 - (t / halfway), 1, 1);
            yield return null;
        }

        // Set the new image
        buttonImage.sprite = newImage;

        // Scale back up to 1
        for (float t = 0; t < halfway; t += Time.deltaTime)
        {
            transform.localScale = new Vector3(t / halfway, 1, 1);
            yield return null;
        }

        // Ensure the scale is set to 1 after the flip
        transform.localScale = Vector3.one;
    }

    private IEnumerator RemoveCard()
    {
        float duration = 0.5f;
        Color initialColor = button.image.color;
        Color targetColor = new Color(initialColor.r, initialColor.g, initialColor.b, 0);

        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            float normalizedTime = t / duration;
            button.image.color = Color.Lerp(initialColor, targetColor, normalizedTime);
            yield return null;
        }

        button.image.color = targetColor;
        button.interactable = false; // Disable the button
    }
}








