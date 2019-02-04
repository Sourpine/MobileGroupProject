using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    private Rigidbody2D rb;
    public int health;
    public int lives = 3;
    public Text healthDisplay;
    public float speed;
    public Text livesText;
    private float moveInput;
    public float jumpForce;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    public float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        lives = PlayerPrefs.GetInt("Lives");

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }
    void Update()
    {
        healthDisplay.text = health.ToString();
        livesText.GetComponent<Text>().text = "Lives: " + lives;
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);


        if(isGrounded == true && Input.GetKeyDown(KeyCode.Space)) { 
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetKey(KeyCode.Space) && isJumping == true){
            if(jumpTimeCounter > 0){
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space)){
            isJumping = false;
        }
        

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            health--;
        }
        if (lives <= 0)
        {
            SceneManager.LoadScene("LoseScreen");
        }
        if (health <= 0)
        {
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            PlayerPrefs.SetInt("Lives", lives--);
            //reload the level
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
        
    }
    
}
