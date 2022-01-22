using UnityEngine;

public class SideManager : MonoBehaviour
{
    public StateEnum economyState = new StateEnum();
    public StateEnum defensesState = new StateEnum();
    public StateEnum technologyState = new StateEnum();

    [Header("Text")]
    [SerializeField] private TMPro.TextMeshProUGUI economyText;
    [SerializeField] private TMPro.TextMeshProUGUI defenseText;
    [SerializeField] private TMPro.TextMeshProUGUI techText;

    public void Awake()
    {
        UpdateState();
    }

    private void UpdateState()
    {
        economyText.SetText(economyState.GetStateString());
        defenseText.SetText(defensesState.GetStateString());
        techText.SetText(technologyState.GetTechnologyString());
    }
}
