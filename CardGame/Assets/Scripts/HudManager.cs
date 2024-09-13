using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    public GameObject redOrBlack;
    public GameObject higherOrLower;
    public GameObject inOrOut;
    public GameObject suits;
    public GameObject winner;

    public Button continueButton;

    public CardManager cardManager;

    int currentIndex = 0;

    void Start()
    {
        StartGame();
    }

    public void ContinueGame()
    {
        currentIndex++;

        switch (currentIndex)
        {
            case 0: RedOrBlack(); break;
            case 1: HigherOrLower(); break;
            case 2: InOrOut(); break;
            case 3: WhatSuit(); break;
            default: Winner(); break;

        }

    }


    public void RedOrBlack()
    {


    }


    public void HigherOrLower()
    {



    }

    public void InOrOut()
    {



    }


    public void WhatSuit()
    {


    }

    public void Winner()
    {

    }


    //Buttons

    public void ColourGuessButton(bool isRed)
    {
        if (true)
        {

        }
    }

    public void HigherOrLowerButton(bool isHigher)
    {

    }

    public void InOrOutButton(bool IsIn)
    {

    }

    public void SuitGuessButton(Suits suit)
    {

    }

    public void ContinueButton()
    {

    }

    public void Quit()
    {

    }

    public void StartGame()
    {
        currentIndex = 0;
        RedOrBlack();
    }

    public void ToggleUIOff()
    {

    }

}
