using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public int shuffleCount = 5;
    public Sprite hidden;

    public CardObject cardObject1;
    public CardObject cardObject2;
    public CardObject cardObject3;
    public CardObject cardObject4;
    public List<Card> cards;

    List<Card> cardsInPlay;

    public List<Card> cardsDrawn;

    void Start()
    {
        PlayGame();
    }

    public void PlayGame()
    {
        cardObject1.gameObject.SetActive(true);
        cardObject1.suitImage.sprite = hidden;
        cardObject1.numberText.text = "";
        cardObject1.numberText2.text = "";

        cardObject2.gameObject.SetActive(false);
        cardObject3.gameObject.SetActive(false);
        cardObject4.gameObject.SetActive(false);

        cardsDrawn.Clear();

        ShuffleCards();
    }

    public void ShuffleCards()
    {
        cardsInPlay = new List<Card>(cards);

        for (int j = 0; j < shuffleCount; j++)
        {
            var count = cardsInPlay.Count;
            var last = count - 1;
            for (var i = 0; i < last; ++i)
            {
                var r = Random.Range(i, count);
                var tmp = cardsInPlay[i];
                cardsInPlay[i] = cardsInPlay[r];
                cardsInPlay[r] = tmp;
            }
        }     
    }

    public void DrawNewCard()
    {
        if (cardsDrawn.Count == 0)
        {
            cardObject1.gameObject.SetActive(true);
            cardObject1.UpdateCardInfo(cardsInPlay[0]);
        }
        else if (cardsDrawn.Count == 1)
        {
            cardObject2.gameObject.SetActive(true);
            cardObject2.UpdateCardInfo(cardsInPlay[0]);
        }
        else if (cardsDrawn.Count == 2)
        {
            cardObject3.gameObject.SetActive(true);
            cardObject3.UpdateCardInfo(cardsInPlay[0]);
        }
        else if (cardsDrawn.Count == 3)
        {
            cardObject4.gameObject.SetActive(true);
            cardObject4.UpdateCardInfo(cardsInPlay[0]);
        }

        cardsDrawn.Add(cardsInPlay[0]);
        cardsInPlay.RemoveAt(0);
    }
}
