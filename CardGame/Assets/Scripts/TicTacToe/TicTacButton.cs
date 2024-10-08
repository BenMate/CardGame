using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TicTacButton : MonoBehaviour
{
    [Header("Component-References")]
    public TTTManager manager;
    public Button interactiveButton;
    public TextMeshProUGUI internalText;

    /// <summary>
    /// Called everytime we press the button, we update the state of this tile.
    /// The internal tracking for whos position (the text component) and disable the button
    /// </summary>
    public void UpdateButton()
    {       
        internalText.text = manager.GetPlayersTurn();
        interactiveButton.image.sprite = manager.GetPlayerSprite();
        interactiveButton.interactable = false;
        manager.CheckForWinner();
    }

    /// <summary>
    /// Resets the tile properties
    /// - text component
    /// - buttton image
    /// </summary>
    public void ResetTile()
    {
        internalText.text = "";
        interactiveButton.image.sprite = manager.tileEmpty;
    }

}
