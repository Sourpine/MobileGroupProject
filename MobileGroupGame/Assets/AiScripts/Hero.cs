using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{
    //fields
    public int healingCooldown = 3;
    public int difAdd = 0;
    private string name;
    private int hp;
    private List<GameObject> textUI;
   //Propeties
    public List<GameObject> TextUI
    {
        get { return textUI; }
        set { textUI = value; }
    }
    public int Hp
    {
        get { return hp; }
        set { hp = value; }
    }
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    //Methods
    private void Start()
    {
        hp = 20;
        //PlayerPrefs.SetInt("DifAdd", difAdd);  this line sets the above difAdd as the one for player prefs so it undoes the difficulty selection
        difAdd = PlayerPrefs.GetInt("DifAdd");
        textUI = new List<GameObject>();
        healingCooldown = PlayerPrefs.GetInt("HealingCooldown");

        //hp += difAdd;
        textUI.Add(gameObject.transform.Find("Name").gameObject);
        textUI.Add(gameObject.transform.Find("HP").gameObject);
        if (gameObject.tag == "EnemyHero")
        {
            hp += difAdd;
            name = "Generic";
            textUI[0].GetComponent<Text>().text = name;
        }
        textUI[1].GetComponent<Text>().text = hp.ToString();
    }
    /// <summary>
    /// Add hero info
    /// </summary>
    /// <param name="name"></param>
    public void AddHeroInfo(string name)
    {
        textUI[0].GetComponent<Text>().text = name;
    }
    /// <summary>
    /// Hero take damage
    /// </summary>
    /// <param name="amount"></param>
    public void TakeDamage(int amount)
    {
        hp -= amount;
        textUI[1].GetComponent<Text>().text = "";
        textUI[1].GetComponent<Text>().text = hp.ToString();
    }
    public void HealPlayer()
    {

        healingCooldown = PlayerPrefs.GetInt("HealingCooldown");
        Debug.Log(healingCooldown);
        if ((gameObject.tag == "PlayerHero") && healingCooldown >= 3)
        {
            hp += 5;
            healingCooldown = 0;
            PlayerPrefs.SetInt("HealingCooldown", healingCooldown);
            Debug.Log("You're Healed");
            textUI[1].GetComponent<Text>().text = "";
            textUI[1].GetComponent<Text>().text = hp.ToString();
        }
    }
    void Update()
    {
        if (gameObject.tag == "EnemyHero")
        {
            PlayerPrefs.SetInt("EnemyHP", hp);
        }
        if (gameObject.tag == "PlayerHero")
        {
            PlayerPrefs.SetInt("PlayerHP", hp);
        }
        if ((gameObject.tag == "PlayerHero") && hp >= 20)
        {
            hp = 20;
            textUI[1].GetComponent<Text>().text = "";
            textUI[1].GetComponent<Text>().text = hp.ToString();
        }
        //ignore the below it is figured out
        /*PlayerPrefs.SetInt("Hp", hp);
        hp = PlayerPrefs.GetInt("Hp");
        //note to max this is where you left off and you need to apply this to the spell on a new script remember this is the enemies hp so don't get that confused*/

    }
}
