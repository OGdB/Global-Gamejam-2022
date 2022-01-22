using UnityEngine;

public class Strength : MonoBehaviour
{
    public int Power = 1;
    void ChangePowerLevel(int amount)
    {
        if (Power + amount <= 0)
        {
            Power = 1;
        }
        else
        {
            Power += amount;
        }
    }
    //pass in target
    void DealDamage()
    {
        //call targets DamageFunction
        
    }
}
