using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DingyAI : MonoBehaviour
{
    public GameObject player;
    public int health;
    public float speed;
    public float radiusToPlayer;
    public bool hasBomb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hasBomb && Vector3.Distance(transform.localPosition, player.transform.localPosition) > radiusToPlayer)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, player.transform.localPosition, speed * Time.deltaTime);
        }
        if(hasBomb && Vector3.Distance(transform.localPosition, player.transform.localPosition) <= radiusToPlayer)
        {
            hasBomb = false;
        }
        if(!hasBomb)
        {
            transform.localPosition -= new Vector3(0, speed * Time.deltaTime);
        }
    }
}
