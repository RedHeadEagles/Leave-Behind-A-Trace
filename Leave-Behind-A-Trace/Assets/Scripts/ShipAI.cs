using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAI : MonoBehaviour
{
    public int health;
    private int timer = 0;
    public float speed;
    private Rigidbody2D rb2d;
    public GameObject cannonball;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer % 100 == 0)
        {
            Instantiate(cannonball, transform.localPosition + new Vector3(0.73f, 0), Quaternion.identity);
            Instantiate(cannonball, transform.localPosition - new Vector3(0.73f, 0), Quaternion.identity);
        }
        timer++;
        transform.localPosition += new Vector3(0, speed * Time.deltaTime);
    }
}
