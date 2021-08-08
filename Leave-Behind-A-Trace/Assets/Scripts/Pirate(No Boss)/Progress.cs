using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progress : MonoBehaviour
{
    public float speed;
    public GameObject player;
    private int prevHealth;
    // Start is called before the first frame update
    void Start()
    {
        prevHealth = player.GetComponent<PlayerManager>().health;
    }

    // Update is called once per frame
    void Update()
    {
        int curr = player.GetComponent<PlayerManager>().health;
        if(playerHit(curr, prevHealth))
        {
            transform.localPosition -= new Vector3(4 * speed * Time.deltaTime, 0, 0);
        }
        else {
            if (transform.localPosition.x < 9.0f)
                transform.localPosition += new Vector3(speed * Time.deltaTime, 0, 0);
            else
                System.Console.WriteLine("Congradulations");
        }

    }
    bool playerHit(int currHealth, int prevHP)
    {
        if (currHealth < prevHP)
        {
            prevHealth = currHealth;
            return true;
        }
        return false;
    }
}
