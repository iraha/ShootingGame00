using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaidarDan : MonoBehaviour
{

    public GameObject waidarDan;
    int count = 0;

    public float shotSpeed = 10.0f;

    public int hindo = 15;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (count % hindo == 0)
        {
            for (int i = 0; i < 12; i++)
            {
                Vector2 vec = new Vector2(0.0f, 1.0f);
                vec = Quaternion.Euler(0, 0, 0.2f * count) * vec;
                vec.Normalize();
                vec = Quaternion.Euler(0, 0, (360 / 12) * i) * vec;
                vec *= shotSpeed;
                var q = Quaternion.Euler(0, 0, -Mathf.Atan2(vec.x, vec.y) * Mathf.Rad2Deg);
                var t = Instantiate(waidarDan, transform.position, q);
                t.GetComponent<Rigidbody2D>().velocity = vec;
            }
        }
        count++;
    }

}
