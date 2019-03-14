using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
public class GUISetting : GUIObject
{
    public Slider[] sliders;
    public Text[] sliderTexts;
    public void Init()
    {
        sliders[0].value = GameManager.Instance.setting.Sensitivity;
        sliders[1].value = GameManager.Instance.setting.Volume;

        SetActive(false);
    }

    public void OnValueChange(int i)
    {
        switch (i)
        {
            case 0:
                GameManager.Instance.setting.Sensitivity = (int)sliders[i].value;
                sliderTexts[i].text = sliders[i].value.ToString();
                break;
            case 1:
                GameManager.Instance.setting.Volume = (int)sliders[i].value;
                sliderTexts[i].text = sliders[i].value.ToString();
                break;
        }
    }
}
