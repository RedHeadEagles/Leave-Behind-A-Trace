using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagerPlatformer : MonoBehaviour
{
    public int health;
    public float speed;
    public int damageMelee;
    public int damageRanged;
    public GameObject projectile;
    private Rigidbody2D rb2d;
    public bool grounded;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health == 0)
        {
            Destroy(gameObject);
        }
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = Vector2.zero;
        if (moveVertical > 0 && grounded)
        {
            //TO-DO: Jump
            movement = new Vector2(moveHorizontal, 35 * moveVertical);
        }
        else if(moveVertical < 0)
        {
            //TO-DO: Duck
        }
        else
        {
            movement = new Vector2(moveHorizontal, 0);
        }
        rb2d.AddForce(movement * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
        if(collision.gameObject.tag == "Enemy")
        {
            Physics2D.IgnoreCollision(transform.GetComponent<Collider2D>(), collision.gameObject.GetComponent<Collider2D>());
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }
}
