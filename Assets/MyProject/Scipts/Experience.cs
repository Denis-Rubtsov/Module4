using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experience
{
    public int ExpPoints {get; private set;}
    public int Level {get; private set;}

    public Experience (int expPoints, int level)
    {
        ExpPoints = expPoints;
        Level = level;
    }

    public void LevelUp(int exp, Health health)
    {
        ExpPoints += exp;
        if (ExpPoints >= Mathf.Pow(2, Level))
        {
            Level++;
            health.IncreaseMaxHealth();
        }
    }

}
