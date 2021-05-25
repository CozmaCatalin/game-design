using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    public int goingDirection;
    public float m_Speed;
    public float m_Lifespan = 8f;
    public LayerMask whatIsSolid;
    public int damage;
    public float distance;

    void Start()
    {
        transform.Rotate(0, 0, goingDirection, 0);
        m_Speed = 45f;
        m_Lifespan = 4f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * m_Speed * Time.deltaTime);
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Player"))
            {
                hitInfo.collider.GetComponent<PlayerController>().TakeDamage(damage);
            }
            Destroy(gameObject);
        }

        Destroy(gameObject, m_Lifespan);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player")) { 
            collision.collider.GetComponent<PlayerController>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
