using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InteractionsManager : MonoBehaviour
{
    [Header("Buttons")]
    public Button DarkDefenseBuffButton;
    public Button LightDefenseBuffButton;
    public Button DarkDefenseDebuffButton;
    public Button LightDefenseDebuffButton;
    public Button DarkTechnologyBuffButton;
    public Button LightTechnologyBuffButton;
    public Button DarkTechnologyDebuffButton;
    public Button LightTechnologyDebuffButton;
    [Header("Text")]
    [SerializeField] private TMPro.TextMeshProUGUI DarkDefenseBuffLabel;
    [SerializeField] private TMPro.TextMeshProUGUI LightDefenseBuffLabel;
    [SerializeField] private TMPro.TextMeshProUGUI DarkDefenseDebuffLabel;
    [SerializeField] private TMPro.TextMeshProUGUI LightDefenseDebuffLabel;
    [SerializeField] private TMPro.TextMeshProUGUI DarkTechnologyBuffLabel;
    [SerializeField] private TMPro.TextMeshProUGUI LightTechnologyBuffLabel;
    [SerializeField] private TMPro.TextMeshProUGUI DarkTechnologyDebuffLabel;
    [SerializeField] private TMPro.TextMeshProUGUI LightTechnologyDebuffLabel;
    [Header("Chaos")]
    public Slider ChaosPointsBar;
    private int maxChaosPoints = 100;
    private int currentChaosPoint = 0;
    public float ChargeRate = 0.5f;
    [SerializeField] private TMPro.TextMeshProUGUI ChaosPointsCount;
   

    
    // Start is called before the first frame update
    void Start()
    {
        //setup Buttons
        DarkDefenseBuffLabel.SetText("Upgrade Dark Defense:\n25CP");
        LightDefenseBuffLabel.SetText("Upgrade Light Defense:\n25CP");
        DarkDefenseDebuffLabel.SetText("Downgrade Dark Defense:\n25CP");
        LightDefenseDebuffLabel.SetText("Downgrade Light Defense:\n25CP");
        DarkTechnologyBuffLabel.SetText("Upgrade Dark Technology:\n25CP");
        LightTechnologyBuffLabel.SetText("Upgrade Light Technology:\n25CP");
        DarkTechnologyDebuffLabel.SetText("Downgrade Dark Technology:\n25CP");
        LightTechnologyDebuffLabel.SetText("Downgrade Light Technology:\n25CP");

        //setup chaos points bar
        ChaosPointsBar.SetValueWithoutNotify(currentChaosPoint);
        
        ChaosPointsCount.SetText(  currentChaosPoint.ToString());
        StartCoroutine(EventsLoop());
    }

    // Update is called once per frame
    public void PurchaseDefenseBuff(SideManager side)
    {
        if (currentChaosPoint >= 25 && side.defensesState.currentState != StateEnum.CurrentState.level2)
        {
            changeChaosPoints(-25);
            side.ChangeDefensesState(1);
        }
    }
    public void PurchaseDefenseDebuff(SideManager side)
    {
        if (currentChaosPoint >= 25&& side.defensesState.currentState!= 0)
        {
            changeChaosPoints(-25);
            side.ChangeDefensesState(-1);
        }
    }
    public void PurchaseTechnologyBuff(SideManager side)
    {
        if (currentChaosPoint >= 25 && side.technologyState.currentState != StateEnum.CurrentState.level2)
        {
            changeChaosPoints(-25);
            side.ChangeTechnologyState(1);
        }
    }
    public void PurchaseTechnologyDebuff(SideManager side)
    {
        if (currentChaosPoint >= 25 && side.technologyState.currentState != 0)
        {
            changeChaosPoints(-25);
            side.ChangeTechnologyState(-1);
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

        ChaosPointsCount.SetText(currentChaosPoint.ToString());
        ChaosPointsBar.SetValueWithoutNotify(currentChaosPoint);
    }
}
