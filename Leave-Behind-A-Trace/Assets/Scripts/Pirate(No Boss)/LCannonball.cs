using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LCannonball : MonoBehaviour
{
    public float speed;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition -= new Vector3(speed * Time.deltaTime,0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == player)
        {
            player.GetComponent<PlayerManager>().health--;
            Destroy(gameObject);
        }
    }
}
