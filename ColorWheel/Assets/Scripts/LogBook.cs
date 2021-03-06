﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class LogBook : MonoBehaviour
{
    public LogBookSlot slotprefab;
    public ColorContainer displayColors;
    public static LogBook logBook;
    public Button pageForwardButton;

    public GameObject editButton;
    // Start is called before the first frame update
    public TMP_Text colorDescription;
    public TMP_Text nameText;
    public TMP_Text heightText;
    public TMP_Text weightText;
    public TMP_Text typeText;
    public TMP_Text hexCode;
    public TMP_Text nicknameText;

    public GameObject inputText;
    public TMP_Text inputTextField;

    public GameObject inputField;

    public Colors currentColor;// this will store information of the currently clicked on slot.

    public Image colorImage;
    public Image colorEnemy;
    public Image colorFriend;
    public Image colorCombo;

    public GameObject descriptionPanel;

    [HideInInspector] public int maxSlots = 9;// Set the maximum number of slots that show up on a single page. Public to other scripts. Private on the inspector.  
    public int pageNumber = 0;
    

    public void Awake()
    {
        logBook = this;
    }
    public void Refresh()//TRefreshes the display based on the current color (so the nickname shows up in real time.)
    {
        FindObjectOfType<AudioManager>().Play("DexClick");
        
        inputText.SetActive(true);
        inputTextField.text = "";
       

        DisplayDescrption(currentColor.unlockText);
        DisplayColorName(currentColor.color);
        DisplayColorType(currentColor.type);
        DisplayColorHex(currentColor.hexText);
        DisplayColorHeight(currentColor.heightText);
        DisplayColorWeight(currentColor.weightText);
        DisplayColorImage(currentColor.dexImageSprite);
        DisplayColorCombo(currentColor.combos);
        DisplayColorEnemy(currentColor.enemies);
        DisplayColorFriend(currentColor.friends);


        
        if (currentColor.hasNickname)//if the boolean 'has nickname is true in the colorTemplate scriptable object.
        {
            DisplayNickname(currentColor.nickname);//initiate this function in Logbook script.
            editButton.SetActive(false);
        }
        else
            DisplayNickname("");//If the scriptable object has no nickname, display nothing.
            editButton.SetActive(true);

        if (editButton.activeSelf == true)
        {
            inputField.SetActive(false);
        }
       
        /*editButton.SetActive(true);*///If the monster has no nickname, then the edit button will appear.

    }
    void OnEnable()
    {
        
        ClearLogbookPage();
        FillLogbookPageBasedOnPageNumber();
    }

    public void ClearLogbookPage()
    {
        foreach (Transform child in transform)//if any slots already exist in the logbook, delete it.
        {
         
            
            Destroy(child.gameObject);
        }
    }

    public void FillLogbookPageBasedOnPageNumber()
    {
            for (int i = 0; i < maxSlots; i++)// This loops runs from zero to the number of max slots. 
            {
               
                int dexNumber = i + maxSlots * pageNumber; // Checks to see it's position in the current pages 1-9

                if ( displayColors.elements.Count < dexNumber)
            {
               /* pageForwardButton.interactable = false;
                Debug.Log(pageForwardButton.interactable);*/
            }

                if (dexNumber > displayColors.elements.Count - 1) break; //If the last entry of the logbook is reached, stop counting. 
                   /* pageForwardButton.interactable = true;*/

            if (displayColors.elements[dexNumber] != null)// 
                {
                    var slot = Instantiate(slotprefab, transform);//creates a new instance of a logbook slot as a reference in the variable.
                    slot.colorTemplate = displayColors.elements[dexNumber];//getting the slot just creating and setting it to the current color on the list.

                }
            }

    }

    //Displays all the information in the dex page.
    public void DisplayDescrption(string description)//displays 'unlock text' text in the description box.
    {
        descriptionPanel.SetActive(true);
        colorDescription.text = description;

    }

    public void DisplayColorName(string name)//Displays the colors name in the description box. 
    {
        nameText.text = name;
    }
    public void DisplayColorWeight(string weight)//Displays the colors' weight in the description box. 
    {
        weightText.text = weight; 
    }
    public void DisplayColorHeight(string height)//Displays the colors' height in the description box. 
    {
        heightText.text = height;
    }
    public void DisplayColorHex(string hexnumber)//Displays the colors' hex code in the description box. 
    {
        hexCode.text = hexnumber;
    }
    public void DisplayColorType(string type)//Displays the color type in the description box. 
    {
        typeText.text = type;
    }
    public void DisplayColorImage(Sprite sprite)//Displays the color type in the description box. 
    {
        colorImage.sprite = sprite;
    }

    public void DisplayNickname(string nickName)
    {
        nicknameText.text = nickName;//Change the nickname to whatever the player input in the name field.
    }
    // Update is called once per frame
    public void DisplayColorFriend(Sprite friend)//Displays friends of this color
    {
        colorFriend.sprite = friend;
    }
    public void DisplayColorEnemy(Sprite enemy)//Displays enemies of this color
    {
        colorEnemy.sprite = enemy;
    }
    public void DisplayColorCombo(Sprite combo)//Displays combos of this color.
    {
        colorCombo.sprite = combo;
    }
    void Update()
    {
        
    }
}
