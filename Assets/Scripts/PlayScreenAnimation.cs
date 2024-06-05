using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayScreenAnimation : MonoBehaviour
{
    [SerializeField] Animator _animator;

    public static Action<String> OnPlayFirst;
    [SerializeField] TMP_Text textLabel;
    private void OnEnable()
    {
        OnPlayFirst += playFirstAnimation;  
    }
    private void OnDisable()
    {
        OnPlayFirst -= playFirstAnimation;      
    }
    public void playFirstAnimation(string msg)
    {
        textLabel.gameObject.SetActive(true);
        textLabel.text = msg;
        _animator.SetTrigger("first");
      
    }   
}
