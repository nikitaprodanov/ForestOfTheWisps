using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Movement variables:
    public float movementSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    public Joystick joystick;

    //Shooting variables:
    public Transform firePoint;
    public GameObject bullet;
    public float bulletSpeed = 100f;
    public float fireRate = 5f;
    public float timer;
    public float health;

    private void Start()
    {
        timer = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = joystick.Horizontal;
        movement.y = joystick.Vertical;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            Shoot();
            timer = fireRate;
        }

        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    }

    void Shoot()
    {
        GameObject bulletClone = Instantiate(bullet, firePoint.position, firePoint.rotation);
        Rigidbody2D bulletRigidBody = bulletClone.GetComponent<Rigidbody2D>();
        bulletRigidBody.AddForce(movement * bulletSpeed * Time.deltaTime, ForceMode2D.Impulse);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}
