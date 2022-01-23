using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InteractionsManager : MonoBehaviour
{
    public Button DarkDefenseBuffButton;
    public Button LightDefenseBuffButton;
    public Button DarkDefenseDebuffButton;
    public Button LightDefenseDebuffButton;
    public Button DarkTechnologyBuffButton;
    public Button LightTechnologyBuffButton;
    public Button DarkTechnologyDebuffButton;
    public Button LightTechnologyDebuffButton;

    public Slider ChaosPointsBar;
    private int maxChaosPoints = 100;
    private int currentChaosPoint = 0;
    public float ChargeRate = 0.5f;
    //public TextMesh ChaosPointsCount;

    
    // Start is called before the first frame update
    void Start()
    {
        //setup Buttons
        /*DarkDefenseBuffButton.GetComponentInChildren<TextMeshPro>().text = "DarkD__++:\n25CP";
        LightDefenseBuffButton.GetComponentInChildren<TextMeshPro>().text = "LightD__++:\n25CP";
        DarkDefenseDebuffButton.GetComponentInChildren<TextMeshPro>().text = "DarkD__--:\n25CP";
        LightDefenseDebuffButton.GetComponentInChildren<TextMeshPro>().text = "LightD__--:\n25CP";
        DarkTechnologyBuffButton.GetComponentInChildren<TextMeshPro>().text = "DarkT__++:\n25CP";
        LightTechnologyBuffButton.GetComponentInChildren<TextMeshPro>().text = "LightT__++:\n25CP";
        DarkTechnologyDebuffButton.GetComponentInChildren<TextMeshPro>().text = "DarkT__--:\n25CP";
        LightTechnologyDebuffButton.GetComponentInChildren<TextMeshPro>().text = "LightT__--:\n25CP";*/

        //setup chaos points bar
        ChaosPointsBar.SetValueWithoutNotify(currentChaosPoint);
        
        //ChaosPointsCount.text = currentChaosPoint.ToString();
        StartCoroutine(EventsLoop());
    }

    // Update is called once per frame
    public void PurchaseDefenseBuff(SideManager side)
    {
        if (currentChaosPoint >= 25)
        {
            changeChaosPoints(-25);
            side.ChangeDefensesState(1);
        }
    }
    public void PurchaseDefenseDebuff(SideManager side)
    {
        if (currentChaosPoint >= 25)
        {
            changeChaosPoints(-25);
            side.ChangeDefensesState(-1);
        }
    }
    public void PurchaseTechnologyBuff(SideManager side)
    {
        if (currentChaosPoint >= 25)
        {
            changeChaosPoints(-25);
            side.ChangeDefensesState(1);
        }
    }
    public void PurchaseTechnologyDebuff(SideManager side)
    {
        if (currentChaosPoint >= 25)
        {
            changeChaosPoints(-25);
            side.ChangeDefensesState(-1);
        }
    }
    
    
    private IEnumerator EventsLoop()
    {
        while (Application.isPlaying)
        {
            // Wait for interval
            yield return new WaitForSeconds(ChargeRate);
            if (currentChaosPoint <= maxChaosPoints-5)
            {
                changeChaosPoints(5);
            }
            
        }
    
}
    public void changeChaosPoints(int amount)
    {
        currentChaosPoint += amount;
        
        //ChaosPointsCount.text = currentChaosPoint.ToString();
        ChaosPointsBar.SetValueWithoutNotify(currentChaosPoint);
    }
}
