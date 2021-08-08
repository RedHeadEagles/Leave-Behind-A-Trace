using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightLShip : MonoBehaviour
{
    public GameObject cannonball;
    private int timer = 0;
    private bool movingUp = false;
    private float yMin = -2.09f;
    private float yMax = 3.65f;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        if (timer % 75 == 0)
        {
            if (Random.Range(0, 100000000) % 20 == 0)
            {
                timer++;
                Destroy(Instantiate(cannonball, transform.localPosition - new Vector3(1.23f, 0), Quaternion.identity),10);
            }
        }
        else
        {
            timer++;
        }
        if (movingUp && transform.localPosition.y < yMax)
        {
            transform.localPosition += new Vector3(0, speed * Time.deltaTime);
            movingUp = transform.localPosition.y < yMax;
        }
        else
        {
            transform.localPosition -= new Vector3(0, speed * Time.deltaTime);
            movingUp = !(transform.localPosition.y > yMin);
        }
    }
}
