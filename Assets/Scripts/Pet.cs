using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet
{
    private string petName;
    private int petFullness;
    private int petHappiness;
    private int petEnergy;

    public string Name
    {
        get
        {
            return petName;
        }
        set
        {
            petName = value;
        }
    }

    public int Fullness
    {
        get
        {
            return petFullness;
        }

        set
        {
            petFullness = value;
        }
    }

    public int Happiness
    {
        get
        {
            return petHappiness;
        }

        set
        {
            petHappiness = value;
        }
    }

    public int Energy
    {
        get
        {
            return petEnergy;
        }

        set
        {
            petEnergy = value;
        }
    }

    public void FeedPet()
    {
        petFullness += 15;
        petEnergy -= Random.Range(0, 10);
        petHappiness -= Random.Range(0, 10);
        if(petFullness > 100)
        {
            petFullness = 100;
        }
    }

    public void RestPet()
    {
        petFullness -= Random.Range(0, 10);
        petEnergy += 15;
        petHappiness -= Random.Range(0, 10);
        if(petEnergy > 100)
        {
            petEnergy = 100;
        }
    }

    public void PlayWithPet()
    {
        petFullness -= Random.Range(0, 10);
        petEnergy -= Random.Range(0, 10);
        petHappiness += 15;
        if(petHappiness > 100)
        {
            petHappiness = 100;
        }
    }

    public Pet(string startingName)
    {
        petName = startingName;
        petFullness = 75;
        petHappiness = 75;
        petEnergy = 75;
    }
}
