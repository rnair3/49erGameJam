using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] float offset;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x - offset * Time.deltaTime, transform.position.y);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            collision.gameObject.GetComponent<Player>().Health(damage);
        }

        if (collision.gameObject.name.Equals("KillPlatform"))
        {
            Destroy(gameObject);
        }

    }
}
