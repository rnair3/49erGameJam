using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] float jumpSpeed = 2f;
    [SerializeField] int health = 100;


    float currentSpeed;
    float targetSpeed;
    [SerializeField] float acceleration = 12;

    BoxCollider2D playerCollider;

    Rigidbody2D rigidbody;
    LevelLoader levelLoader;

    // Start is called before the first frame update
    void Start()
    {
        levelLoader = FindObjectOfType<LevelLoader>();
        rigidbody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Jump();
    }


    public void Run()
    {
        float controlFlow = Input.GetAxis("Horizontal");
        Vector2 velocity = new Vector2(controlFlow * speed, rigidbody.velocity.y);
        rigidbody.velocity = velocity;

        bool playerHasHorizontalVelocity = Mathf.Abs(rigidbody.velocity.x) > Mathf.Epsilon;
        //animator.SetBool("isWalking", playerHasHorizontalVelocity);
    }

    private void Jump()
    {
        if (!playerCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }

        if (Input.GetButtonDown("Jump"))
        {
            Vector2 jumpVelocity = new Vector2(0f, jumpSpeed);
            rigidbody.velocity += jumpVelocity;
        }
    }


    public void Health(int damage)
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            levelLoader.GameOver();
            //death animation + music
        }
        health -= damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Kill") || collision.gameObject.name.Equals("KillPlatform"))
        {
            Destroy(gameObject);
            levelLoader.GameOver();
        }
    }

}
