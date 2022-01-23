using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Slider slider;
    public SideManager darkSideManager;
    public SideManager lightSideManager;

    int totalTowers = 12;

    private void FixedUpdate()
    {
        int totalTowers = darkSideManager.amountOfTowersLeft + lightSideManager.amountOfTowersLeft;
        slider.SetValueWithoutNotify(darkSideManager.amountOfTowersLeft / totalTowers);
    }
}
