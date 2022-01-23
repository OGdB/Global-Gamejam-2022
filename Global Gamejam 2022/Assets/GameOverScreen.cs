using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI topText;
    [SerializeField] private TMPro.TextMeshProUGUI subText;

    private void OnEnable()
    {
        topText.SetText($"{Blackboard.winner} has conquered {Blackboard.loser}");
        subText.SetText("Balance was lost");
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
