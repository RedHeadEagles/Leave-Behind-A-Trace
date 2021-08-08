using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LShipAI : MonoBehaviour
{
    public GameObject manager;
    public int health;
    public GameObject cannonball;
    private Rigidbody2D rb2d;
    private int timer = 0;
    public GameObject mast;
    private bool movingRight = false;
    private float xMin = -8.46f;
    private float xMax = 8.46f;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = transform.GetComponent<Rigidbody2D>();
        manager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        if(health == 0)
        {
            manager.GetComponent<LevelManager>().amountShip++;
            Instantiate(mast, transform.localPosition - new Vector3(0, 2), Quaternion.identity);
            Destroy(gameObject);
        }
        if (timer % 75 == 0)
        {
            if (Random.Range(0, 100000000) % 20 == 0)
            {
                timer++;
                Destroy(Instantiate(cannonball, transform.localPosition - new Vector3(0, 1.23f), Quaternion.identity),10);
            }
        }
        else
        {
            timer++;
        }
        if(movingRight && transform.localPosition.x < xMax)
        {
            transform.localPosition += new Vector3(speed * Time.deltaTime, 0);
            movingRight = transform.localPosition.x < xMax;
        }
        else
        {
            transform.localPosition -= new Vector3(speed * Time.deltaTime, 0);
            movingRight = !(transform.localPosition.x > xMin);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Projectile")
        {
            health--;
        }
        if(collision.gameObject.tag == "Enemy")
        {
            movingRight = !movingRight;
        }
    }
}
