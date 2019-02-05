using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum CardType
{
    Weapon,
    Armour,
    Spell,
}

public class CardAsset : MonoBehaviour


{
    // this object will hold the info about the most general card
    [Header("General info")]
    public string Description;  // Description for spell or character
    public Sprite CardImage;
    public CardType Cardtype;

    [Header("Weapon Info")]
    public int Defence;
    public int Attack;
    public int Speed;
    public string WeaponScriptName;
    public int specialCreatureAmount;


}

