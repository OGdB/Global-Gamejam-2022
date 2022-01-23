using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionsManager : MonoBehaviour
{
    public Button DefenseBuffButton;
    public Button DefenseDebuffButton;
    public Button DarkDefenseBuffButton;
    public Button LightDefenseBuffButton;
    public Button DarkDefenseDebuffButton;
    public Button LightDefenseDebuffButton;
    public Button TechnologyBuffButton;
    public Button TechnologyDebuffButton;
    public Button DarkTechnologyBuffButton;
    public Button LightTechnologyBuffButton;
    public Button DarkTechnologyDebuffButton;
    public Button LightTechnologyDebuffButton;

    // Start is called before the first frame update
    void Start()
    {
        DarkDefenseBuffButton.enabled = false;
        LightDefenseBuffButton.enabled = false;
        DarkDefenseDebuffButton.enabled = false;
        LightDefenseDebuffButton.enabled = false;
        DarkTechnologyBuffButton.enabled = false;
        LightTechnologyBuffButton.enabled = false;
        DarkTechnologyDebuffButton.enabled = false;
        LightTechnologyDebuffButton.enabled = false;
    }

    // Update is called once per frame
    public void DefenseBuffOnclick()
    {
        //if CP>30
        DefenseBuffButton.enabled = false;
        DarkDefenseBuffButton.enabled = true;
        LightDefenseBuffButton.enabled = true;
    }
    public void DefenseDebuffOnclick()
    {
        //if CP>30
        DefenseDebuffButton.enabled = false;
        DarkDefenseDebuffButton.enabled = true;
        LightDefenseDebuffButton.enabled = true;
    }
    public void DarkDefenseBuffOnclick()
    {
        print("boop");
        //call side function
        //CP-=30
        DefenseBuffButton.enabled = true;
        DarkDefenseBuffButton.enabled = false ;
        LightDefenseBuffButton.enabled = false;

    }
    public void LightDefenseBuffOnclick()
    {
        print("boop");
        //call side function
        //CP-=30
        DefenseBuffButton.enabled = true;
        DarkDefenseBuffButton.enabled = false;
        LightDefenseBuffButton.enabled = false;

    }
    public void DarkDefenseDebuffOnclick()
    {
        print("boop");
        //call side function
        //CP-=30
        DefenseDebuffButton.enabled = true;
        DarkDefenseDebuffButton.enabled = false;
        LightDefenseDebuffButton.enabled = false;

    }
    public void LightDefenseDebuffOnclick()
    {
        print("boop");
        //call side function
        //CP-=30
        DefenseDebuffButton.enabled = true;
        DarkDefenseDebuffButton.enabled = false;
        LightDefenseDebuffButton.enabled = false;

    }
    public void TechnologyBuffOnclick()
    {
        //if CP>30
        TechnologyBuffButton.enabled = false;
        DarkTechnologyBuffButton.enabled = true;
        LightTechnologyBuffButton.enabled = true;

    }
    public void TechnologyDebuffOnclick()
    {
        //if CP>30
        TechnologyDebuffButton.enabled = false;
        DarkTechnologyDebuffButton.enabled = true;
        LightTechnologyDebuffButton.enabled = true;

    }
    public void DarkTechnologyBuffOnclick()
    {
        print("boop");
        //call side function
        //CP-=30
        TechnologyBuffButton.enabled = true;
        DarkTechnologyBuffButton.enabled = false;
        LightTechnologyBuffButton.enabled = false;

    }
    public void LightTechnologyBuffOnclick()
    {
        print("boop");
        //call side function
        //CP-=30
        TechnologyBuffButton.enabled = true;
        DarkTechnologyBuffButton.enabled = false;
        LightTechnologyBuffButton.enabled = false;

    }
    public void DarkTechnologyDebuffOnclick()
    {
        print("boop");
        //call side function
        //CP-=30
        TechnologyDebuffButton.enabled = true;
        DarkTechnologyDebuffButton.enabled = false;
        LightTechnologyDebuffButton.enabled = false;

    }
    public void LightTechnologyDebuffOnclick()
    {
        print("boop");
        //call side function
        //CP-=30
        TechnologyDebuffButton.enabled = true;
        DarkTechnologyDebuffButton.enabled = false;
        LightTechnologyDebuffButton.enabled = false;

    }
    void Update()
    {

    }
}
