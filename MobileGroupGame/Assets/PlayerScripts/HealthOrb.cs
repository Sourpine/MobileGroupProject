using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthOrb : MonoBehaviour
{
    public int playerHP = 0;
    public int enemyHP = 0;
    public int difAdd = PlayerPrefs.GetInt("DifAdd");
    public int enemyMax = 0;
    public int difMult = 1;
    public GameObject Full;
    public GameObject Second;
    public GameObject Third;
    public GameObject Fourth;
    public GameObject Fifth;
    public GameObject Sixth;
    public GameObject Seventh;
    public GameObject Eighth;
    public GameObject Ninth;
    public GameObject Tenth;
    public GameObject EFull;
    public GameObject ESecond;
    public GameObject EThird;
    public GameObject EFourth;
    public GameObject EFifth;
    public GameObject ESixth;
    public GameObject ESeventh;
    public GameObject EEighth;
    public GameObject ENinth;
    public GameObject ETenth;
    // Start is called before the first frame update
    void Start()
    {
        DisableObjects();
        EDisableObjects();
        PlayerPrefs.GetInt("DifAdd", difAdd);
        difAdd = PlayerPrefs.GetInt("DifAdd");
        enemyMax = 20 + difAdd;
        PlayerPrefs.GetInt("PlayerHP", playerHP);
        playerHP = PlayerPrefs.GetInt("PlayerHP", playerHP);
        PlayerPrefs.GetInt("EnemyHP", enemyHP);
        enemyHP = PlayerPrefs.GetInt("EnemyHP", enemyHP);
        if(difAdd == 0)
        {
            difMult = 2;
        }
        if (difAdd == 10)
        {
            difMult = 3;
        }
        if (difAdd == 20)
        {
            difMult = 4;
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.GetInt("DifAdd", difAdd);
        difAdd = PlayerPrefs.GetInt("DifAdd");
        PlayerPrefs.GetInt("PlayerHP", playerHP);
        playerHP = PlayerPrefs.GetInt("PlayerHP", playerHP);
        PlayerPrefs.GetInt("EnemyHP", enemyHP);
        enemyHP = PlayerPrefs.GetInt("EnemyHP", enemyHP);
        enemyMax = 20 + difAdd;
        //players health ord code
        if (playerHP == 20)
        {
            DisableObjects();
            Full.SetActive(true);
        }
        if(playerHP >= 18 && playerHP < 20)
        {
            DisableObjects();
            Second.SetActive(true);
        }
        if(playerHP >= 16 && playerHP < 18)
        {
            DisableObjects();
            Third.SetActive(true);
        }
        if(playerHP >= 14 && playerHP < 16)
        {
            DisableObjects();
            Fourth.SetActive(true);
        }
        if(playerHP >= 11 && playerHP < 14)
        {
            DisableObjects();
            Fifth.SetActive(true);
        }
        if(playerHP >= 9 && playerHP < 11)
        {
            DisableObjects();
            Sixth.SetActive(true);
        }
        if(playerHP >= 7 && playerHP < 9)
        {
            DisableObjects();
            Seventh.SetActive(true);
        }
        if (playerHP >= 5 && playerHP < 7)
        {
            DisableObjects();
            Eighth.SetActive(true);
        }
        if(playerHP >= 3 && playerHP < 5)
        {
            DisableObjects();
            Ninth.SetActive(true);
        }
        if(playerHP >= 1 && playerHP < 3)
        {
            DisableObjects();
            Tenth.SetActive(true);
        }

        //enemy orb code

        if (enemyHP == 10 * difMult)
        {
            EDisableObjects();
            EFull.SetActive(true);
        }
        if (enemyHP >= 9 * difMult && enemyHP < 10 * difMult)
        {
            EDisableObjects();
            ESecond.SetActive(true);
        }
        if (enemyHP >= 8 && enemyHP < 9 * difMult)
        {
            EDisableObjects();
            EThird.SetActive(true);
        }
        if (enemyHP >= 7 && enemyHP < 8 * difMult)
        {
            EDisableObjects();
            EFourth.SetActive(true);
        }
        if (enemyHP >=6 && enemyHP < 7 * difMult)
        {
            EDisableObjects();
            EFifth.SetActive(true);
        }
        if (enemyHP >= 5 && enemyHP < 6 * difMult)
        {
            EDisableObjects();
            ESixth.SetActive(true);
        }
        if (enemyHP >= 4 && enemyHP < 5 * difMult)
        {
            EDisableObjects();
            ESeventh.SetActive(true);
        }
        if (enemyHP >= 3 && enemyHP < 4 * difMult)
        {
            EDisableObjects();
            EEighth.SetActive(true);
        }
        if (enemyHP >= 2 && enemyHP < 3 * difMult)
        {
            EDisableObjects();
            ENinth.SetActive(true);
        }
        if (enemyHP >= 1 && enemyHP < 2 * difMult)
        {
            EDisableObjects();
            ETenth.SetActive(true);
        }
    }
    public void DisableObjects()
    {
        Full.SetActive(false);
        Second.SetActive(false);
        Third.SetActive(false);
        Fourth.SetActive(false);
        Fifth.SetActive(false);
        Sixth.SetActive(false);
        Seventh.SetActive(false);
        Eighth.SetActive(false);
        Ninth.SetActive(false);
        Tenth.SetActive(false);
    }
    public void EDisableObjects()
    {
        EFull.SetActive(false);
        ESecond.SetActive(false);
        EThird.SetActive(false);
        EFourth.SetActive(false);
        EFifth.SetActive(false);
        ESixth.SetActive(false);
        ESeventh.SetActive(false);
        EEighth.SetActive(false);
        ENinth.SetActive(false);
        ETenth.SetActive(false);
    }
}
