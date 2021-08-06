using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LShipAI : MonoBehaviour
{
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
    }

    // Update is called once per frame
    void Update()
    {
        if(health == 0)
        {
            Instantiate(mast, transform.localPosition - new Vector3(0, 2), Quaternion.identity);
        }
        if (timer % 75 == 0)
        {
            if (Random.Range(0, 100000000) % 20 == 0)
            {
                timer++;
                Instantiate(cannonball, transform.localPosition - new Vector3(0, 1.23f), Quaternion.identity);
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
}
