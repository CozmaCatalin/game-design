using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject[] hearts;
    public int heartsNumber;
    public Text score;

    private Rigidbody2D rb;
    private Animator anim;

    public float speed;
    public float jumpForce;

    public bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private float jumpTimeCounter;
    public float jumpTime;
    public bool isJumping;

    public Animator camAnim;
    public int health = 50;
    public int maxHealth = 50;
    public GameObject deathEffect;
    public GameObject explosion;
    public Slider playerHealth;
    public int currentCoins;
    public AudioSource coinCollect;

    public GameObject weapon;
    public GameObject weaponPos;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        coinCollect = GetComponent<AudioSource>();
        Instantiate(ShopManager.selectedWeapon.weapon, weaponPos.transform.position, transform.rotation, weaponPos.transform);
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.L))
        //{
        //    Instantiate(weapon, weaponPos.transform.position, transform.rotation,weaponPos.transform);
        //}

        playerHealth.value = health;
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        if (difference.x > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }
        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }

        if(health <= 0)
        {
            //Destroy(gameObject);
            TakeHearth();
        }

    }

    private void FixedUpdate()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");

        if (moveInput != 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    public void TakeDamage(int damage)
    {
        camAnim.SetTrigger("shake");
        Instantiate(explosion, transform.position, Quaternion.identity);
        health -= damage;
    }

    public void TakeHearth()
    {
        if(heartsNumber > 0)
        {
            heartsNumber -= 1;
            Destroy(hearts[heartsNumber].gameObject);
            health = maxHealth;
        } else
        {
            Destroy(gameObject);
        }
    }

    public void AddOrRemoveCoins(int amount)
    {
        score.text = (int.Parse(score.text) + amount).ToString();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            AddOrRemoveCoins(collision.gameObject.GetComponent<Coin>().value);
            Destroy(collision.gameObject);
            coinCollect.Play();
        }
    }
}
