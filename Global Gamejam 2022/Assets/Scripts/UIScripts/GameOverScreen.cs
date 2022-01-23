using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI BigText;
    [SerializeField] private TMPro.TextMeshProUGUI WinnerText;
    [SerializeField] private TMPro.TextMeshProUGUI ScoreText;

    private void OnEnable()
    {
        BigText.SetText("The War Has Ended!");
        WinnerText.SetText($"{Blackboard.winner} has triumphed over {Blackboard.loser}");
        ScoreText.SetText($"You kept the war going for {Blackboard.TimeLasted} years");
    }

    public void OnRestart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
    public void OnQuit()
    {
        Application.Quit();
    }
}
