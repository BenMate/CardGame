using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TTTManager : MonoBehaviour
{
    [Header("Referances")]
    public TextMeshProUGUI winnerText;
    public Image playerXIcon;
    public Image PlayerOIcon;
    public GameObject gameOverObjects;

    [Header("Asset-References")]
    public Sprite tilePlayerO;
    public Sprite tilePlayerX;
    public Sprite tileEmpty; 

    public TextMeshProUGUI[] tileList;
    //[0] [1] [2]
    //[3] [4] [5]
    //[6] [7] [8]

    [Header("Game-state References")]
    public Color inactiveColour;
    public Color activeColour;
    public string whoPlaysFirst = "X";
    public string playersTurn;
    public int moveCount;

    void Start()
    {
        playersTurn = whoPlaysFirst;
        if (playersTurn == "X") PlayerOIcon.color = inactiveColour;
        else playerXIcon.color = inactiveColour;

        gameOverObjects.SetActive(false);
    }

    public void CheckForWinner()
    {
        //this is terrible..... make a loop checking rows and columns best this works for now....dont hate

        moveCount++;
        if (tileList[0].text == playersTurn && tileList[1].text == playersTurn && tileList[2].text == playersTurn) GameOver(playersTurn);
        else if (tileList[3].text == playersTurn && tileList[4].text == playersTurn && tileList[5].text == playersTurn) GameOver(playersTurn);
        else if (tileList[6].text == playersTurn && tileList[7].text == playersTurn && tileList[8].text == playersTurn) GameOver(playersTurn);
        else if (tileList[0].text == playersTurn && tileList[3].text == playersTurn && tileList[6].text == playersTurn) GameOver(playersTurn);
        else if (tileList[1].text == playersTurn && tileList[4].text == playersTurn && tileList[7].text == playersTurn) GameOver(playersTurn);
        else if (tileList[2].text == playersTurn && tileList[5].text == playersTurn && tileList[8].text == playersTurn) GameOver(playersTurn);
        else if (tileList[0].text == playersTurn && tileList[4].text == playersTurn && tileList[8].text == playersTurn) GameOver(playersTurn);
        else if (tileList[2].text == playersTurn && tileList[4].text == playersTurn && tileList[6].text == playersTurn) GameOver(playersTurn);
        else if (moveCount >= 9) GameOver("D");
        else
            ChangeTurn();
    }

    public void ChangeTurn()
    {
        //checks whos turn it is and swap it to the other
        playersTurn = (playersTurn == "X") ? "O" : "X";

        if (playersTurn == "X")
        {
            playerXIcon.color = activeColour;
            PlayerOIcon.color = inactiveColour;
        }
        else
        {
            playerXIcon.color = inactiveColour;
            PlayerOIcon.color = activeColour;
        }

    }

    public void GameOver(string winningPlayer)
    {
        switch (winningPlayer)
        {
            case "D": winnerText.text = "DRAW"; break;
            case "X": winnerText.text = playersTurn + " Wins!"; break;
            case "O": winnerText.text = playersTurn + " Wins!"; break;         
        }

        gameOverObjects.SetActive(true);
        ToggleButtonState(false);
    }

    public void RestartGame()
    {
        // Reset some gamestate properties
        moveCount = 0;
        playersTurn = whoPlaysFirst;
        ToggleButtonState(true);
        gameOverObjects.SetActive(false);

        // Loop though all tiles and reset them
        for (int i = 0; i < tileList.Length; i++)
        {
            tileList[i].GetComponentInParent<TicTacButton>().ResetTile();
        }
    }

    private void ToggleButtonState(bool state)
    {
        for (int i = 0; i < tileList.Length; i++)
        {
            tileList[i].GetComponentInParent<Button>().interactable = state;
        }
    }

    //getters

    public string GetPlayersTurn()
    {
        return playersTurn;
    }

    public Sprite GetPlayerSprite()
    {
        if (playersTurn == "X") return tilePlayerX;
        else return tilePlayerO;
    }

    public void ChangeSceneViaPath(string scenePath)
    {
        SceneManager.LoadScene(scenePath);
    }
}
