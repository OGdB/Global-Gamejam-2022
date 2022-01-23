using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Slider slider;
    public SideManager darkSideManager;
    public SideManager lightSideManager;

    float totalTowers = 12;

    private void FixedUpdate()
    {
        totalTowers = darkSideManager.amountOfTowersLeft + lightSideManager.amountOfTowersLeft;
        //print(darkSideManager.amountOfTowersLeft/totalTowers);
        slider.SetValueWithoutNotify((darkSideManager.amountOfTowersLeft / totalTowers)*100);
    }
}
