using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progress : MonoBehaviour
{
    public float speed;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition.x < 9.0f)
            transform.localPosition += new Vector3(speed * Time.deltaTime, 0, 0);
        else
            System.Console.WriteLine("Congradulations");

    }
}
