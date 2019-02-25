using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmenyHP : MonoBehaviour
{
    public int enemyHP = 100;
    public int enemyMana = 0;
    public int playerHP = PlayerPrefs.GetInt("PlayerHP");
    public int numberOfPlayerCards = 3;
    public int numberOfEnemyCards = 3;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("EnemyHP", enemyHP);
        PlayerPrefs.SetInt("PlayerHP", playerHP);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("EnemyHP", enemyHP);
        enemyHP = PlayerPrefs.GetInt("EnemyHP");
        //playerHP = PlayerPrefs.GetInt("PlayerHP");
        PlayerPrefs.SetInt("PlayerHP", playerHP);
        playerHP = PlayerPrefs.GetInt("PlayerHP");
        if (enemyHP >= 200)
        {
            enemyHP = 200;
        }
        if (playerHP >= 200)
        {
            playerHP = 200;
        }
    }
    //beginning of healing category
    public void healSelf()
    {
        enemyHP += 5;
    }
    public void drainHealth()
    {
        enemyHP += 3;
        playerHP -= 3;
    }
    public void waveHeal()
    {
        enemyHP += 10;
        playerHP += 4;
    }
    public void conversion()
    {
        enemyHP -= 5;
        enemyMana += 5;
    }
    //beginning of shield category
    //don't yet know how to do shields
    public void impenitrableDefense()
    {

    }
    public void basicShield()
    {

    }
    public void advancedShield()
    {

    }
    public void waningShield()
    {

    }
    //beginning of attack category
    public void fireball()
    {
        playerHP -= 5;
    }
    public void fieldAnnihilation()
    {
        //don't know how to do this yet
    }
    public void shieldCurse()
    {
        //this is another later one (don't know yet)
    }
    public void lightningBolt()
    {
        playerHP -= 6;
    }
    public void pricedPain()
    {
        enemyHP -= 4;
        playerHP -= 8;
    }
    public void bloodiedCurse()
    {
        //wont be able to do until turns are figured out
    }
    public void targetedAnnihilation()
    {
        //same as field annihilation
    }
    public void blast()
    {
        playerHP -= (5 + numberOfPlayerCards);
    }
    //beginning of the other catgory
    //these are obscure and will likely all be unknown (do later)
    public void timeUndone()
    {
        //undo last actions
    }
    public void timeRedone()
    {
        //redo last action
    }
    public void freezeSpell()
    {
        //dissables a spell an the field
    }
    public void freezeEnemy()
    {
        //skip the enemy's next turn
    }
    public void callForAid()
    {
        //pull 2 cards from the deck
        numberOfEnemyCards += 2;
    }
    public void endlessMana()
    {
        //next turn cast spells from the field free of charge
    }
    public void haltedPurchase()
    {
        //next turn gain two mana but you may not gain a card
    }
    public void haltedMana()
    {
        //next turn gain two cards at the expense of gaining mana
    }
    public void theFiftiethCoin()
    {
        //i forgot that this is a troll
        /*int chance = Random.Range(0, 100);
        if (chance == 20)
        {
            enemyHP -= 10;
        }
        else
        {
            playerHP = 0;
        }*/
        enemyHP -= 10;
    }
}
