using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strength : MonoBehaviour
{
    //Amount of damage the thing is able todo
    private int Power = 1;
    


    public void ChangePowerLevel(int amount)
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
    public void DealDamage()
    {
        //call targets DamageFunction
        
    }
}
