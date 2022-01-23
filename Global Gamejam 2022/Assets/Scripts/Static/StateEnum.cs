public class StateEnum
{
    public CurrentState currentState;
    public StateEnum(CurrentState currentState = CurrentState.average)
    {
        this.currentState = currentState;
    }

    public enum CurrentState
    {
        horrible = 0,
        very_bad = 1,
        bad = 2,
        average = 3,
        good = 4,
        very_good = 5,
        excellent = 6
    };

    public void ChangeState(int change) => currentState += change;

    /// <summary>
    /// Return a formatted string of the current state.
    /// </summary>
    public string GetStateString()
    {
        switch (currentState)
        {
            case CurrentState.horrible:
                return "Horrible";
            case CurrentState.very_bad:
                return "Very Bad";
            case CurrentState.bad:
                return "Bad";
            case CurrentState.average:
                return "Average";
            case CurrentState.good:
                return "Good";
            case CurrentState.very_good:
                return "Very Good";
            case CurrentState.excellent:
                return "Excellent";
            default: 
                return null;
        }
    }

    /// <summary>
    /// Get the state returned as a degree of technology advancement
    /// </summary>
    public string GetTechnologyString()
    {
        switch (currentState)
        {
            case CurrentState.horrible:
                return "Stone Age";
            case CurrentState.very_bad:
                return "Bronze Age";
            case CurrentState.bad:
                return "Iron Age";
            default:
                return null;
        }
    }
}