using UnityEngine;
using UnityEngine.UI;
public class SideManager : MonoBehaviour
{
    public StateEnum defensesState = new StateEnum();
    public StateEnum technologyState = new StateEnum(0);

    public GameObject[] soldierPrefabs; // Soldier prefabs in the order of worst to best

    public Transform lightBase;
    public Transform darkBase;

    public void Awake()
    {
        SetCurrentTroop();
        UpdateStates();
    }


    public bool ChangeDefensesState(int change)
    {
        if (change <= -1 && defensesState.currentState == StateEnum.CurrentState.level1)
            return false;

        defensesState.currentState += change;

        UpdateStates();
        return true;
    }
    public bool ChangeTechnologyState(int change)
    {
        if ((change <= -1 && technologyState.currentState == StateEnum.CurrentState.level1) || (change >= 1 && technologyState.currentState == StateEnum.CurrentState.level2))
            return false;

        technologyState.currentState += change;
        SetCurrentTroop();

        UpdateStates();
        return true;
    }

    private void SetCurrentTroop()
    {
        if (gameObject.tag == "Dark")
        {
            Blackboard.currentDarkTroop = soldierPrefabs[(int)technologyState.currentState];
        }
        else if (gameObject.tag == "Light")
        {
            Blackboard.currentLightTroop = soldierPrefabs[(int)technologyState.currentState];
        }
    }

    public bool ChangeRandomState(int change)
    {
        float random = Random.Range(-1f, 1f);
        if (random < 0)
        {
            bool success = ChangeDefensesState(change);
            return success;
        }
        else
        {
            bool success = ChangeTechnologyState(change);
            return success;
        }
    }

    [Header("Text")]
    [SerializeField] private TMPro.TextMeshProUGUI defenseText;
    [SerializeField] private TMPro.TextMeshProUGUI techText;
    [Header("Images")]
    [SerializeField] private Image defenseImage;
    [SerializeField] private Image techImage;
    [SerializeField] private Sprite stoneAgeImg;
    [SerializeField] private Sprite BronzeAgeImg;
    [SerializeField] private Sprite IronAgeImg;
    [SerializeField] private GameObject loseScreen;
    [SerializeField] private Image BalancedefenseImage;
    [SerializeField] private Image BalancetechImage;
    [SerializeField] private Sprite Level1Img;
    [SerializeField] private Sprite Level2Img;
    [SerializeField] private Sprite Level3Img;
    
    /// <summary>
    /// Updates the states visually
    /// </summary>
    private void UpdateStates()
    {
        defenseText.SetText(defensesState.GetStateString());
        techText.SetText(technologyState.GetTechnologyString());
        switch (defensesState.GetStateString())
        {
            case "level1":
                defenseImage.sprite = Level1Img;
                BalancedefenseImage.sprite = Level1Img;
                break;
            case "level2":
                defenseImage.sprite = Level2Img;
                BalancedefenseImage.sprite = Level1Img;
                break;
            case "level3":
                defenseImage.sprite = Level3Img;
                BalancedefenseImage.sprite = Level1Img;
                break;
            default:
                break;
        }
        switch (technologyState.GetTechnologyString())
        {
            case "Stone Age":
                techImage.sprite = stoneAgeImg;
                BalancetechImage.sprite = stoneAgeImg;
                break;
            case "Bronze Age":
                techImage.sprite = BronzeAgeImg;
                BalancetechImage.sprite = stoneAgeImg;
                break;
            case "Iron Age":
                techImage.sprite = IronAgeImg;
                BalancetechImage.sprite = stoneAgeImg;
                break;
            default:
                break;
        }
       

    }
}
