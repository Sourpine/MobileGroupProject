using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HP : MonoBehaviour {

    public int health = 3;
    public Text healthText;
    public Slider healthBar;
    float timer = 0;
    public float HealthRegen = 0.3f;
    public int lives = 5;

    void Start()
    {
        //PlayerPrefs.SetInt("Lives", lives);
        lives = PlayerPrefs.GetInt("Lives");
        healthText.GetComponent<Text>().text = "Health: " + health;
        healthBar.GetComponent<Slider>().value = health;
        if (lives <= 0)
        {
            SceneManager.LoadScene("LoseScene");
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        healthText.GetComponent<Text>().text = "Health: " + health;
        healthBar.GetComponent<Slider>().value = health;
        timer += Time.deltaTime;
        if (collision.gameObject.tag == "Enemy" && GetComponent<Rigidbody2D>().velocity.y == 0)
        {
            health--;
            
        }
        if (collision.gameObject.name == "DeathFloor")
        {
            health = 0;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        /*if (collision.gameObject.tag == "HealthPotion")
        {
            health = 3;
            Destroy(collision.gameObject);
        }*/
        /*if (collision.gameObject.tag == "Boss")
        {
            health -= 20;
        }*/

        if (health <= 0)
        {
            PlayerPrefs.SetInt("Lives", lives - 1);
            //reload the level
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            
        }
        if (lives <= 0)
        {
            SceneManager.LoadScene("LoseScene");
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        
       
    }
        
void OnEnterTrigger2D(Collider2D collision)
    {
        //this is for the refill of health in an HP zone
    }

}
