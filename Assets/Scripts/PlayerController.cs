﻿using System.Collections;
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
    public float health;
    public float maxHealth;
    public GameObject deathEffect;
    public GameObject explosion;
    public Slider playerHealth;
    public int currentCoins;
    public AudioSource coinCollect;

    public GameObject weapon;
    public GameObject weaponPos;

    private void Start()
    {
        for(int i = 1; i <= 3; i++)
        {
            hearts[i - 1] = GameObject.Find("Heart" + i);
        }
        speed = 20 + (ShopManager.speed * 30);
        float HEALTH = 25 + ShopManager.health * 250;
        playerHealth = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<Slider>();
        playerHealth.maxValue = HEALTH;
        playerHealth.value = HEALTH;
        health = HEALTH;
        maxHealth = HEALTH;
        camAnim = GameObject.Find("Main Camera").GetComponent<Animator>();
        score = GameObject.Find("CoinsValue").GetComponent<Text>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        coinCollect = GetComponent<AudioSource>();
        Instantiate(ShopManager.selectedWeapon.weapon, weaponPos.transform.position, transform.rotation, weaponPos.transform);
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.L))
        {
            Instantiate(weapon, weaponPos.transform.position, transform.rotation, weaponPos.transform);
        }

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
        float defenseDamage = (1-ShopManager.strength) * damage;
        camAnim.SetTrigger("shake");
        Instantiate(explosion, transform.position, Quaternion.identity);
        health -= defenseDamage;
    }

    public void TakeHearth()
    {
        if(heartsNumber > 0)
        {
            heartsNumber -= 1;
            Destroy(hearts[heartsNumber].gameObject);
            GamePlay gp = GameObject.Find("GamePlay").GetComponent<GamePlay>();
            transform.position = gp.spawnPositions[gp.playerSpawnPoint].position;
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
        GameObject c = collision.gameObject;
        if (c.CompareTag("EnterWave"))
        {
            GameObject.Find("GamePlay").GetComponent<GamePlay>().EnterWave();
        }
        if (c.CompareTag("Coin"))
        {
            AddOrRemoveCoins(c.GetComponent<Coin>().value);
            Destroy(collision.gameObject);
            coinCollect.Play();
        }
        if (c.CompareTag("Limit"))
        {
            health = 0;
        }
        if (c)
        {
            rb.AddForce(transform.up * 1f, ForceMode2D.Impulse);
        }

    }

}
