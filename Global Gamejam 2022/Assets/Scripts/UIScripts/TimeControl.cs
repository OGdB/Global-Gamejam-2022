using UnityEngine;

public class TimeControl : MonoBehaviour
{
    public void SetTime(int scale)
    {
        Time.timeScale = scale;
    }
}
