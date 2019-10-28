using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    public float speed;

    public Text scoreText;
    public Text livesText;
    public Text winText;
    public AudioSource musicSource;
    public AudioClip musicClip;

    private int scoreValue;
    private int livesValue;
    private int pickups;
    private Rigidbody2D rd2d;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rd2d = GetComponent<Rigidbody2D>();
        winText.text = "";
        scoreText.text = "Score: ";
        livesText.text = "Lives: 3";
        pickups = 4;
        livesValue = 3;
        scoreValue = 0;
        SetScoreText();
        SetLivesText();

    }

    void Update()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Input.GetAxis("Vertical") * 15f * Time.deltaTime, 0f, 0f);
        transform.Translate(Input.GetAxis("Horizontal") * 15f * Time.deltaTime, 0f, 0f);
        Vector2 characterScale = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0)
        {
            characterScale.x = -1;
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = 1;
        }
        transform.localScale = characterScale;

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetInteger("State", 1);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {

            anim.SetInteger("State", 0);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetInteger("State", 1);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetInteger("State", 0);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {

            anim.SetInteger("State", 3);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetInteger("State", 0);
        }


    }

    void OnTriggerEnter2D(Collider2D other)
    {
       


        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            scoreValue = scoreValue + 1;
            pickups = pickups - 1;
            SetScoreText();
        }


        if (other.gameObject.CompareTag("UFO"))
        {
            other.gameObject.SetActive(false);
            livesValue = livesValue - 1;
            
            SetLivesText();
        }

    }



    void SetScoreText()
    {
        scoreText.text = "Score: " + scoreValue.ToString();
        if (scoreValue >= 4)
        {
            winText.text = "YOU WON!! Game made by Kevin Le";
        }
    }

    void SetLivesText()
    {
        livesText.text = "Lives: " + livesValue.ToString();
        if (livesValue <= 0)
        {
            winText.text = "Awww D: You lose T-T ;-;";
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
            }
        }
    }
}