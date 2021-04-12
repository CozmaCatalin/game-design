using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordManEnemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Stats")]
    public float speed;
    private float stoppingDistance;
    public Rigidbody2D rb;
    public Animator Animator;
    public Transform player;
    public float jumpForce;
    public bool isAttacking;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    public bool isGrounded;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        speed = 12;
        stoppingDistance = 3;
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (player != null)
        {

            if(transform.position.x < player.transform.position.x) 
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);

            }
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            if (Mathf.Abs(distanceToPlayer - stoppingDistance) <= 1f)
            {
                Animator.SetBool("isRunning", false);
                if (!isAttacking)
                {
                    Animator.SetTrigger("atack");
                    isAttacking = true;
                }
                //Debug.Log("[1]");

            } else if (distanceToPlayer > stoppingDistance)
            {
                Animator.SetBool("isRunning", true);
                isAttacking = false;
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                //Debug.Log("[2]" + distanceToPlayer);
            }


        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle") && isGrounded)
        {
            Debug.Log("Enemy will jump on " + collision.name);
            rb.velocity = Vector2.up * (collision.GetComponent<Obstacle>().height + 2f);
        }
    }
}