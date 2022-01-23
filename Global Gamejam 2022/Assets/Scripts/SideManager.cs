using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SideManager : MonoBehaviour
{
    public string thisTag;
    public StateEnum defensesState = new StateEnum();
    public StateEnum technologyState = new StateEnum(0);
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private Transform enemySpawnPoint;
    [SerializeField] private GameObject[] soldierPrefabs; // Soldier prefabs in the order of worst to best
    private Coroutine spawnCoroutine;

    public Transform lightBase;
    public Transform darkBase;
    public int spawnTroopInterval = 10;

    private void Start()
    {
        spawnCoroutine = StartCoroutine(SpawnTroopLoop());
    }
    public bool ChangeDefensesState(int change)
    {
        if (change <= -1 && defensesState.currentState == StateEnum.CurrentState.horrible)
            return false;

        defensesState.currentState += change;

        UpdateStates();
        return true;
    }
    public bool ChangeTechnologyState(int change)
    {
        if ((change <= -1 && technologyState.currentState == StateEnum.CurrentState.horrible) || (change >= 1 && technologyState.currentState == StateEnum.CurrentState.bad))
            return false;

        technologyState.currentState += change;

        UpdateStates();
        return true;
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

    public void Awake()
    {
        UpdateStates();
    }

    /// <summary>
    /// Updates the states visually
    /// </summary>
    private void UpdateStates()
    {
        defenseText.SetText(defensesState.GetStateString());
        techText.SetText(technologyState.GetTechnologyString());
        switch (technologyState.GetTechnologyString())
        {
            case "Stone Age":
                techImage.sprite = stoneAgeImg;
                break;
            case "Bronze Age":
                techImage.sprite = BronzeAgeImg;
                break;
            case "Iron Age":
                techImage.sprite = IronAgeImg;
                break;
            default:
                break;
        }

    }



    public void SpawnTroop()
    {
        if (spawnPoint.gameObject.activeInHierarchy && enemySpawnPoint.gameObject.activeInHierarchy)
        {
            GameObject newTroop = Instantiate(soldierPrefabs[(int)technologyState.currentState], position: spawnPoint.position, Quaternion.identity);
            // Find enemy base
            if (thisTag == "Dark")
            {
                newTroop.GetComponent<AI>().targetBase = lightBase.position;
            }
            else
            {
                newTroop.GetComponent<AI>().targetBase = darkBase.position;
            }
        }
        else
        {
            if (!spawnPoint.gameObject.activeInHierarchy) // if this spawnpoint was destroyed
            {
                Blackboard.loser = thisTag;
                if (thisTag == "Light")
                {
                    Blackboard.winner = "Dark";
                }
                else if (thisTag == "Dark")
                {
                    Blackboard.winner = "Light";
                }
            }

            StopCoroutine(spawnCoroutine);

            // GAME OVER SCREEN
            loseScreen.SetActive(true);

        }
    }

    private IEnumerator SpawnTroopLoop()
    {
        while (Application.isPlaying)
        {
            yield return new WaitForSeconds(spawnTroopInterval);
            SpawnTroop();
        }
    }
}
