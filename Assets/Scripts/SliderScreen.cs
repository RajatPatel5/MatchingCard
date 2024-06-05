using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScreen :MonoBehaviour
{
    [SerializeField] private Slider slider;

    bool LodingComplet = false;

    private void Start()
    {
        slider.value = 0;
    }   
    void Update()
    {
        if (slider.value >= 0.97 && !LodingComplet)
        {
            UIManager.Instance.StartCanvas.enabled = false;
            UIManager.Instance.PlayButtonCanvas.enabled = true;
            LodingComplet = true;
        }
        else
        {
            slider.value += Time.deltaTime / 1f;
        }
    }
}
