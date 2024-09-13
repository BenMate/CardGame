using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Suits 
{
    diamond, heart, spade, club
}

[CreateAssetMenu(fileName = "NewCard", menuName = "Card/NewCard")]
public class Card : ScriptableObject
{
    public int value;
    public bool isRed;
    public Suits suit;
}
