﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UCannonball : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += new Vector3(0, speed * Time.deltaTime);
    }
}
