﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[CreateAssetMenu (fileName ="Colors", menuName ="MonsterColor", order=1)] 
public class Colors: ScriptableObject
{
    public string color;
    public string nickname;
    public string type;
    public string unlockText;
    public string hexText;
    public string heightText;
    public string weightText; 
    public Sprite sprite;
    public Sprite BookSprite;
    public Sprite dexImageSprite;
    public Sprite redResult;
    public Sprite blueResult;
    public Sprite yellowResult;
    public Sprite pastelYellowResult;
    public Sprite pastelBlueResult;
    public Sprite pastelRedResult;
    public Sprite friends;
    public Sprite enemies;
    public Sprite combos;


    public bool hasNickname = false;
   

    //these are all containters for sprites that will be displayed when players use a specific needle to interact with a color. 
    public Colors redNeedleUnlock;
    public Colors yellowNeedleUnlock;
    public Colors blueNeedleUnlocked;

    public Colors pastelBlueUnlocked;
    public Colors pastelRedUnlocked;
    public Colors pastelYellowunlocked;
  



    public Colors(string newColor, string newType)
    {
        color = newColor;
        type = newType;
    }

}
