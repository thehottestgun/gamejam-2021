using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
   [NonSerialized] public string playerName = PlayerStats.name;
    public string NPCName;
    public AudioClip[] Clips;
    [TextArea(3,10)]
    public string[] sentences;
    
}
