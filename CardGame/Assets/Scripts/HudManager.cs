using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HudManager : MonoBehaviour
{
    public GameObject redOrBlack;
    public GameObject higherOrLower;
    public GameObject inOrOut;
    public GameObject suits;
    public GameObject winner;
    public GameObject loser;

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

    //when a button is pushed, call this function
    public void ToggleContinueButton(bool state)
    {
        continueButton.gameObject.SetActive(state);
    }

    //functions for each game stage
    void RedOrBlack()
    {
        ToggleAllOFf();
        redOrBlack.gameObject.SetActive(true);
    }

    void HigherOrLower()
    {
        ToggleAllOFf();
        higherOrLower.gameObject.SetActive(true);

    }

    void InOrOut()
    {
        ToggleAllOFf();
        inOrOut.gameObject.SetActive(true);
    }

    void WhatSuit()
    {
        ToggleAllOFf();
        suits.gameObject.SetActive(true);
    }

    void Winner()
    {
        ToggleAllOFf();
        winner.gameObject.SetActive(true);
    }

    void Loser()
    {
        ToggleAllOFf();
        loser.gameObject.SetActive(true);
    }

    void ToggleAllOFf()
    {
        redOrBlack.gameObject.SetActive(false);
        higherOrLower.gameObject.SetActive(false);
        inOrOut.gameObject.SetActive(false);
        suits.gameObject.SetActive(false);
        winner.gameObject.SetActive(false);
        continueButton.gameObject.SetActive(false);
        loser.gameObject.SetActive(false);
    }

    //called by the buttons

    public void ColourGuessButton(bool isRedGuess)
    {
        cardManager.DrawNewCard();

        if (isRedGuess) //red guess button
        {
            //players card that was drawn is a red suited card
            if (cardManager.cardObject1.cardInfo.suit == Suits.diamond || cardManager.cardObject1.cardInfo.suit == Suits.heart)
                ContinueGame();
            else Loser();
        }
        else
        {
            if (cardManager.cardObject1.cardInfo.suit == Suits.spade || cardManager.cardObject1.cardInfo.suit == Suits.club)
                ContinueGame();
            else Loser();
        }
    }

    public void HigherOrLowerButton(bool isHigher)
    {
        cardManager.DrawNewCard();

        if (isHigher) //red guess button
        {
            if (cardManager.cardObject2.cardInfo.value > cardManager.cardObject1.cardInfo.value)
                ContinueGame();
            else Loser();
        }
        else
        {
            if (cardManager.cardObject2.cardInfo.value < cardManager.cardObject1.cardInfo.value)
                ContinueGame();
            else Loser();
        }
    }

    public void InOrOutButton(bool IsIn)
    {
        cardManager.DrawNewCard();

        int card1 = cardManager.cardObject1.cardInfo.value;
        int card2 = cardManager.cardObject2.cardInfo.value;
        int newCard = cardManager.cardObject3.cardInfo.value;

        //sort the cords in assecnding order
        if (cardManager.cardObject1.cardInfo.value < cardManager.cardObject2.cardInfo.value)
        {
            card1 = cardManager.cardObject1.cardInfo.value;
            card2 = cardManager.cardObject2.cardInfo.value;
        }
        else if (cardManager.cardObject1.cardInfo.value > cardManager.cardObject2.cardInfo.value)
        {
            card1 = cardManager.cardObject2.cardInfo.value;
            card2 = cardManager.cardObject1.cardInfo.value;
        }
        
        //check if the new card is in between card 1 and 2 or out
        if (IsIn)
        {
            if (newCard > card1 && newCard < card2)
                ContinueGame();
            else Loser();
        }
        else
        {
            if (newCard < card1 || newCard > card2)
                ContinueGame();
            else Loser();
        }
    }

    public void SuitGuessButton(int suit)
    {
        cardManager.DrawNewCard();

        switch (suit)
        {
            case 1: if (cardManager.cardObject4.cardInfo.suit == Suits.diamond) ContinueGame(); break;
            case 2: if (cardManager.cardObject4.cardInfo.suit == Suits.heart) ContinueGame(); break;
            case 3: if (cardManager.cardObject4.cardInfo.suit == Suits.spade) ContinueGame(); break;
            case 4: if (cardManager.cardObject4.cardInfo.suit == Suits.club) ContinueGame(); break;
            default: Loser(); break;
        }
    }

    public void Quit()
    {
        Application.Quit(); //go to menu for other games
    }

    public void StartGame()
    {
        cardManager.PlayGame();
        currentIndex = 0;

        RedOrBlack();      
    }


}
