using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAI : MonoBehaviour
{
    public GameObject manager;
    public int health;
    private int timer = 0;
    public float speed;
    private Rigidbody2D rb2d;
    public GameObject cannonballL;
    public GameObject cannonballR;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = transform.GetComponent<Rigidbody2D>();
        manager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            manager.GetComponent<LevelManager>().amountShip++;
            Destroy(gameObject);
        }
        if (timer % 100 == 0)
        {
            Destroy(Instantiate(cannonballR, transform.localPosition + new Vector3(0.73f, 0), Quaternion.identity),10);
            Destroy(Instantiate(cannonballL, transform.localPosition - new Vector3(0.73f, 0), Quaternion.identity),10);
        }
        timer++;
        transform.localPosition += new Vector3(0, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            health--;
        }
    }
}
