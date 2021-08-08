using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int health;
    private Rigidbody2D rb2d;
    public GameObject cannonball;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis("Vertical");

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        rb2d.velocity = movement * speed;
        if (Input.GetButton("Fire1"))
        {
            Destroy(Instantiate(cannonball, transform.localPosition + new Vector3(0, 0.73f), Quaternion.identity),10);
        }
    }
}
