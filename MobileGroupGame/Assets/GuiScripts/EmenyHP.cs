using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmenyHP : MonoBehaviour
{
    public int enemyHP = 100;
    public int enemyMana = 0;
    public int playerHP = PlayerPrefs.GetInt("PlayerHP");

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("EnemyHP", enemyHP);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("EnemyHP", enemyHP);
        enemyHP = PlayerPrefs.GetInt("EnemyHP");
        playerHP = PlayerPrefs.GetInt("PlayerHP");
        PlayerPrefs.SetInt("PlayerHP", playerHP);
        if (enemyHP >= 200)
        {
            enemyHP = 200;
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

}
