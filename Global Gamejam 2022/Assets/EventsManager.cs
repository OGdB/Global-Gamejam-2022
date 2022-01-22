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
    [Range(0, 60)]
    public int eventInterval = 45;

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

            yield return new WaitForFixedUpdate();
        }
    }

    private void RandomEvent(SideManager side)
    {
        float random = Random.Range(-1f, 1f);
        if (random < 0)
            GoodEvent();
        else
            BadEvent();

        void GoodEvent()
        {
            side.ChangeRandomState(1);
            print($"Good event for {side.name}!");
        }

        void BadEvent()
        {
            side.ChangeRandomState(-1);
            print($"Bad event for {side.name}!");
        }
    }
}
