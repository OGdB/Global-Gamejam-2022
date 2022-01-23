public class StateEnum
{
    public CurrentState currentState;
    public StateEnum(CurrentState currentState = CurrentState.level2)
    {
        this.currentState = currentState;
    }

    public enum CurrentState
    {
        level1 = 0,
        level2 = 1,
        level3 = 2,
    };

    public void ChangeState(int change) => currentState += change;

    /// <summary>
    /// Return a formatted string of the current state.
    /// </summary>
    public string GetStateString()
    {
        switch (currentState)
        {
            case CurrentState.level1:
                return "Level 1";
            case CurrentState.level2:
                return "Level 2";
            case CurrentState.level3:
                return "Level 3";
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
            case CurrentState.level1:
                return "Stone Age";
            case CurrentState.level2:
                return "Bronze Age";
            case CurrentState.level3:
                return "Iron Age";
            default:
                return null;
        }
    }
}