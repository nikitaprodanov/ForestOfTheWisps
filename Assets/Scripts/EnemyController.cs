using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float health;
    public float seenRange;
    public Rigidbody2D rb;
    public float speed;
    public Transform player;
    public float range;

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
            Destroy(gameObject);
        }
        FollowPlayer();
    }

    public void TakeDamage (float damage)
    {
        health -= damage;
    }

    void FollowPlayer()
    {
        if (Vector2.Distance(transform.position, player.position) < range)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }
}
