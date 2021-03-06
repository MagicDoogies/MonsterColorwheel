﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LogBookSlot : MonoBehaviour
{
    public Colors colorTemplate; 
    public Image sprite;
    public TMP_Text colorName;

    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        sprite.sprite = colorTemplate.BookSprite;//the sprite image is set to the image sprite in the referenced scriptable object.

        colorName.text = colorTemplate.color;

        
    }

    public void ShowDescription()
    {

        
        /*
        LogBook.logBook.DisplayDescrption(colorTemplate.unlockText);
        LogBook.logBook.DisplayColorName(colorTemplate.color);
        LogBook.logBook.DisplayColorType(colorTemplate.type);
        LogBook.logBook.DisplayColorHex(colorTemplate.hexText);
        LogBook.logBook.DisplayColorHeight(colorTemplate.heightText);
        LogBook.logBook.DisplayColorWeight(colorTemplate.weightText);
        LogBook.logBook.DisplayColorImage(colorTemplate.dexImageSprite);*/

        LogBook.logBook.currentColor = colorTemplate;//Takes in all the information from the currently selected scriptable object.
        LogBook.logBook.Refresh();
        
        /*if (colorTemplate.hasNickname)//if the boolean 'has nickname is true in the colorTemplate scriptable object.
        {
            LogBook.logBook.DisplayNickname(colorTemplate.nickname);//initiate this function in Logbook script.
        }
        else
            LogBook.logBook.DisplayNickname("");//If the scriptable object has no nickname, display nothing.
        */


    }
}
