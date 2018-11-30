using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resolution : MonoBehaviour 
{
    public Slider slider;
    public Text text;
    public static int currentSliderValue; // current slider value
    // you have to change the max value by yourself
    public static int MaxValue = 100;

    private void Awake()
    {
        slider.maxValue = MaxValue;
        // set the half of the maxValue as the default slider value;
        // slider.value = MaxValue / 4.0f;
        slider.value = 10;
        currentSliderValue = (int)slider.value;
    }

    private void Update()
    {
        currentSliderValue = (int)slider.value;
        // update text
        text.text = currentSliderValue.ToString() + " x " + currentSliderValue.ToString();
    }

}
