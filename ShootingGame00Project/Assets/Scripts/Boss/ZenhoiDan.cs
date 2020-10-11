using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZenhoiDan : MonoBehaviour
{

    public GameObject player;
    public GameObject zenhoiDan;
    public float shotSpeed = 7.0f;
    int count = 0;
    public int hindo = 50;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

        if (player == true)
        {
            if (count % hindo == 0)
            {
                for (int i = 0; i < 16; i++)
                {
                    Vector2 vec = player.transform.position - transform.position;
                    vec.Normalize();
                    // 16分割
                    vec = Quaternion.Euler(0, 0, (360 / 16) * i) * vec;
                    vec *= shotSpeed;
                    var t = Instantiate(zenhoiDan, transform.position, zenhoiDan.transform.rotation);
                    t.GetComponent<Rigidbody2D>().velocity = vec;
                }
            }
        }
        else if (player == false)
        {

        }
        count++;
    }


}
