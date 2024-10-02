using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardObject : MonoBehaviour
{
    public Sprite spades;
    public Sprite hearts;
    public Sprite diamonds;
    public Sprite clubs;

    [Space]

    public Image suitImage;
    public TextMeshProUGUI numberText;
    public TextMeshProUGUI numberText2;

    public Card cardInfo;

    public void UpdateCardInfo(Card newCard)
    {
        cardInfo = newCard;

        //change colour and suit image
        switch (newCard.suit)
        {
            case Suits.diamond: 
                suitImage.sprite = diamonds; numberText.color = Color.red;  numberText2.color = Color.red; break;

            case Suits.heart:
                suitImage.sprite = hearts; numberText.color = Color.red; numberText2.color = Color.red; break;

            case Suits.spade:
                suitImage.sprite = spades; numberText.color = Color.black; numberText2.color = Color.black; break;

            case Suits.club:
                suitImage.sprite = clubs; numberText.color = Color.black; numberText2.color = Color.black; break;
        }

        //change text value
        int value = newCard.value;  

        if (value == 1) //ace
        {
            numberText.text = "A";
            numberText2.text = "A";
        }
        else if (value > 1 && value < 11) //above ace below jack
        {
            numberText.text = value.ToString();
            numberText2.text = value.ToString();
        }
        else if (value == 11) //jack
        {
            numberText.text = "J";
            numberText2.text = "J";
        }
        else if (value == 12) //queen
        {
            numberText.text = "Q";
            numberText2.text = "Q";
        }
        else if (value == 13) //king
        {
            numberText.text = "K";
            numberText2.text = "K";
        }
        else if (value == 14) //ace
        {
            numberText.text = "A";
            numberText2.text = "A";
        }
        else
        {
            numberText.text = "Error";
            numberText2.text = "Error";
        }
    }
}
