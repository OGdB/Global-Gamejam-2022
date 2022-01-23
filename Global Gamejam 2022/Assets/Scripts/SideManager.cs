using System.Collections;
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
    public void ChangeDefensesState(int change)
    {
        if (change <= -1 && defensesState.currentState == 0)
            return;

        defensesState.currentState += change;

        UpdateStates();
    }
    public void ChangeTechnologyState(int change)
    {
        if ((change <= -1 && technologyState.currentState == 0) || (change >= 1 && technologyState.currentState == StateEnum.CurrentState.bad))
            return;

        technologyState.currentState += change;

        UpdateStates();
    }
    public void ChangeRandomState(int change)
    {
        float random = Random.Range(-1f, 1f);
        if (random < 0)
        {
            ChangeDefensesState(change);
        }
        else
        {
            ChangeTechnologyState(change);
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
        if (spawnPoint != null && enemySpawnPoint != null)
        {
            GameObject newTroop = Instantiate(soldierPrefabs[(int)technologyState.currentState], position: spawnPoint.position, Quaternion.identity);
            // Find enemy base
            if (thisTag == "Dark")
            {
                newTroop.GetComponent<AI>().targetBase = transform.TransformPoint(lightBase.position);
            }
            else
            {
                newTroop.GetComponent<AI>().targetBase = transform.TransformPoint(darkBase.position);
            }
        }
        else
        {
            if (spawnPoint == null)
                print($"{thisTag}'s spawnpoint destroyed!");
            else
                print("Enemy spawnpoint destroyed!");

            StopCoroutine(spawnCoroutine);

            // GAME OVER SCREEN
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
