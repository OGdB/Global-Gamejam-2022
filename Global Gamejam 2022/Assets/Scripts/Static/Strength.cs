using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strength : MonoBehaviour
{
    private int Power = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangePowerLevel(int amount)
    {
        if (Power += amount <= 0)
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
