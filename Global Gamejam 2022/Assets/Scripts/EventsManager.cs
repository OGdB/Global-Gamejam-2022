using System.Collections;
using UnityEngine;

/// <summary>
/// The Events manager causes events causing (mis)fortune for either side, giving the other more fortune and possibly changing the tides.
/// </summary>
public class EventsManager : MonoBehaviour
{
    [SerializeField] 
    private SideManager lightSideManager;
    [SerializeField] 
    private SideManager darkSideManager;
    [SerializeField]
    private TMPro.TextMeshProUGUI messageText;
    [Range(1, 60)]
    public int eventInterval = 45;
    [Range(1, 15)]
    public int eventIntervalDecreaseRate = 1;
    public string[] randomBadMessages;
    public string[] randomGoodMessages;


    private void Start() => StartCoroutine(EventsLoop());

    private IEnumerator EventsLoop()
    {
        while (Application.isPlaying)
        {
            // Wait for interval
            yield return new WaitForSeconds(eventInterval);

            // Cause Event, randomly lightside or darkside
            float random = Random.Range(-1f, 1f);
            if (random < 0)
                RandomEvent(lightSideManager);
            else
                RandomEvent(darkSideManager);

            if (eventInterval > 1)
            {
                eventInterval -= eventIntervalDecreaseRate;
            }
        }
    }

    private void RandomEvent(SideManager side)
    {
        float random = Random.Range(-1f, 1f);
        string sideName = side.name;
        if (random < 0)
            GoodEvent(sideName);
        else
            BadEvent(sideName);

        void GoodEvent(string sideName)
        {
            bool succes = side.ChangeRandomState(1);

            if (succes)
                RandomGoodEventMessage(sideName);
        }

        void BadEvent(string sideName)
        {
            bool success = side.ChangeRandomState(-1);

            if (success)
                RandomBadEventMessage(sideName);
        }
    }
    private void RandomBadEventMessage(string sidename)
    {
        int randomBadInt= Random.Range(0, randomBadMessages.Length - 1);

        string randomBadString = randomBadMessages[randomBadInt];

        messageText.SetText($"{sidename}'s {randomBadString}");
    }
    private void RandomGoodEventMessage(string sidename)
    {
        int randomGoodInt = Random.Range(0, randomGoodMessages.Length - 1);

        string randomGoodString = randomGoodMessages[randomGoodInt];

        messageText.SetText($"{sidename}'s {randomGoodString}");
    }
}
