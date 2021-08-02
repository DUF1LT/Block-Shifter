using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class GameSettings 
{
    [SerializeField]
    public int Level { get; }

    public GameSettings(int level)
    {
        Level = level;
    }
}
