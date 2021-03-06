﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KisuuDan : MonoBehaviour
{

    public GameObject kisuuDan;
    public float shotSpeed = 6.0f;

    int count = 0;
    public int hindo = 60;

    public GameObject player;
    // Use this for initialization
    void Start()
    {

        player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        int wayNum = 5;
        float angle = 30.0f;
        count++;

        if (player == true)
        {
            if (count % hindo == 0)
            {
                for (int i = 0; i < wayNum; i++)
                {
                    Vector2 vec = player.transform.position - transform.position;
                    vec.Normalize();
                    float anglePerShot = angle / (wayNum - 1);
                    vec = Quaternion.Euler(0, 0, anglePerShot * i - angle / 2.0f) * vec;
                    vec *= shotSpeed;
                    var q = Quaternion.Euler(0, 0, -Mathf.Atan2(vec.x, vec.y) * Mathf.Rad2Deg);
                    var t = Instantiate(kisuuDan, transform.position, q);
                    t.GetComponent<Rigidbody2D>().velocity = vec;
                }
            }
        }
        else if (player == false)
        {

        }
        
    }

}
