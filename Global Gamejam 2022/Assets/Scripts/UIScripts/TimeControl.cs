using UnityEngine;

public class TimeControl : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI text;
    public void SetTime(int scale)
    {
        Time.timeScale = scale;
        text.SetText($"{scale}x");
    }
}
