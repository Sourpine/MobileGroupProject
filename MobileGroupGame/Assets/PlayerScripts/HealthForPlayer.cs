using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthForPlayer : MonoBehaviour
{
    public int health = 3;
    public Text healthText;
    public Slider healthBar;

    // Start is called before the first frame update
    void Start()
    {
        healthText.GetComponent<Text>().text = "Health: " + health;
        healthBar.GetComponent<Slider>().value = health;
    }

    public void OnTakeDamage()
    {

    }
}
