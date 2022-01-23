using System.Collections;
using UnityEngine;

public class SideManager : MonoBehaviour
{
    private StateEnum defensesState = new StateEnum();
    private StateEnum technologyState = new StateEnum(0);
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField] private GameObject[] soldierPrefabs;

    public Transform lightBase;
    public Transform darkBase;
    public int spawnTroopInterval = 10;

    private void Start()
    {
        StartCoroutine(SpawnTroopLoop());
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
        if ((change <= -1 && technologyState.currentState == 0) || (change <= 1 && technologyState.currentState == StateEnum.CurrentState.bad))
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
    }

    /// <summary>
    /// Spawn a
    /// </summary>
    public void SpawnTroop()
    {
        GameObject newTroop = Instantiate(soldierPrefabs[(int)technologyState.currentState], position: spawnPoint.position, Quaternion.identity);
        // Find enemy base
        if (gameObject.tag == "Dark")
        {
            newTroop.GetComponent<AI>().targetBase = transform.TransformPoint(lightBase.position);
            newTroop.GetComponent<AI>().enemyTag = "Light";
        }
        else
        {
            newTroop.GetComponent<AI>().targetBase = transform.TransformPoint(darkBase.position);
            newTroop.GetComponent<AI>().enemyTag = "Dark";
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
