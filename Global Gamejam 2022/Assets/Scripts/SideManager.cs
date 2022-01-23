using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SideManager : MonoBehaviour
{
    public StateEnum defensesState = new StateEnum(0);
    public StateEnum technologyState = new StateEnum(0);
    public static List<Spawner> lightSideSpawns = new List<Spawner>();
    public static List<Spawner> darkSideSpawns = new List<Spawner>();
    public int amountOfTowersLeft = 6;
    

    public GameObject[] soldierPrefabs; // Soldier prefabs in the order of worst to best
    public GameObject[] towerPrefabs; // Soldier prefabs in the order of worst to best

    public void Awake()
    {
        Spawner[] _spawns = FindObjectsOfType<Spawner>();

        for (int i = 0; i < _spawns.Length; i++)
        {
            Spawner spawn = _spawns[i];
            if (spawn.tag == "Light" && gameObject.tag == "Light")
            {
                lightSideSpawns.Add(spawn);
            }
            else if (spawn.tag == "Dark" && gameObject.tag == "Dark")
            {
                darkSideSpawns.Add(spawn);
            }
        }

        UpdateStates();
    }


    public bool ChangeDefensesState(int change)
    {
        if (change <= -1 && defensesState.currentState == StateEnum.CurrentState.level1 || (change >= 1 && defensesState.currentState == StateEnum.CurrentState.level2))
            return false;

        defensesState.currentState += change;
        // Update all towers to the correct models
        TowerAI[] towers = FindObjectsOfType<TowerAI>();
        GameObject newModel = GetCurrentTower();
        foreach (TowerAI tower in towers)
        {
            if (tower.tag == gameObject.tag)
            {
                // Completely replace the towers;

                Instantiate(newModel, tower.transform.position, newModel.transform.rotation, tower.transform.parent);
                Destroy(tower.gameObject);
                amountOfTowersLeft++;
            }
        }

        UpdateStates();
        return true;
    }
    public bool ChangeTechnologyState(int change)
    {
        if ((change <= -1 && technologyState.currentState == StateEnum.CurrentState.level1) || (change >= 1 && technologyState.currentState == StateEnum.CurrentState.level2))
            return false;

        technologyState.currentState += change;

        UpdateStates();
        return true;
    }

    public GameObject GetCurrentTroop()
    {
        return soldierPrefabs[(int)technologyState.currentState];
    }
    public GameObject GetCurrentTower()
    {
        return towerPrefabs[(int)defensesState.currentState];
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
            case "Level 1":
                defenseImage.sprite = Level1Img;
                BalancedefenseImage.sprite = Level1Img;
                break;
            case "Level 2":
                defenseImage.sprite = Level2Img;
                BalancedefenseImage.sprite = Level2Img;
                break;
            case "Level 3":
                defenseImage.sprite = Level3Img;
                BalancedefenseImage.sprite = Level3Img;
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
                BalancetechImage.sprite = BronzeAgeImg;
                break;
            case "Iron Age":
                techImage.sprite = IronAgeImg;
                BalancetechImage.sprite = IronAgeImg;
                break;
            default:
                break;
        }
       

    }
}
