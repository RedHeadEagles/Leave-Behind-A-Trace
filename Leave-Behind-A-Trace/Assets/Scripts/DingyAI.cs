using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DingyAI : MonoBehaviour
{
    public GameObject manager;
    public GameObject player;
    public int health;
    public float speed;
    public float radiusToPlayer;
    public bool hasBomb;
    public GameObject bomb;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        manager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        if(health == 0)
        {
            manager.GetComponent<LevelManager>().amountShip++;
            Destroy(gameObject);
        }
        if(hasBomb && Vector3.Distance(transform.localPosition, player.transform.localPosition) > radiusToPlayer)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, player.transform.localPosition, speed * Time.deltaTime);
        }
        if(hasBomb && Vector3.Distance(transform.localPosition, player.transform.localPosition) <= radiusToPlayer)
        {
            Instantiate(bomb, new Vector3(transform.localPosition.x +0.48f,transform.localPosition.y), Quaternion.identity);
            hasBomb = false;
        }
        if(!hasBomb)
        {
            transform.localPosition -= new Vector3(0, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            health--;
        }
    }
}
