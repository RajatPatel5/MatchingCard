using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CardEvents 
{
    public static event Action<Card> OnCardFlipped;
    public static event Action<Card> OnCardMatched;

    public static void CardFlipped(Card card)
    {
        OnCardFlipped?.Invoke(card);
    }

    public static void CardMatched(Card card)
    {
        OnCardMatched?.Invoke(card);
    }
}


