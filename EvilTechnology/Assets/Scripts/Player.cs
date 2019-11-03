using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] float jumpSpeed = 2f;
    [SerializeField] int health = 100;

    Rigidbody2D rigidbody;
    LevelLoader levelLoader;

    // Start is called before the first frame update
    void Start()
    {
        levelLoader = FindObjectOfType<LevelLoader>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalThrow = Input.GetAxis("Horizontal");
        Vector2 velocity = new Vector2(horizontalThrow * speed, rigidbody.velocity.y);
        rigidbody.velocity = velocity;

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
        if (collision.gameObject.name.Equals("Kill"))
        {
            Destroy(gameObject);
            levelLoader.GameOver();
        }
    }

}
