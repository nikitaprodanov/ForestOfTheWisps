using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int gainingScore = 20;
    public float health;
    public Rigidbody2D rb;
    public float speed;
    public Transform player;
    public float seenRange;
    public float damage;

    private void Start()
    {
        GameObject target = GameObject.FindGameObjectWithTag("Player");
        player = target.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().GainScore(this.gainingScore);
            Destroy(gameObject);
        }

        FollowPlayer();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
        }
    }

    public void TakeDamage (float damage)
    {
        health -= damage;
    }

    void FollowPlayer()
    {
        if (Vector2.Distance(transform.position, player.position) < seenRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }
}
