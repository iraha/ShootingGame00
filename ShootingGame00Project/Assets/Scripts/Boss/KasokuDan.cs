using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KasokuDan : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 画面外なら消す範囲は省略
        var v = GetComponent<Rigidbody2D>().velocity;
        v = 1.02f * v;
        GetComponent<Rigidbody2D>().velocity = v;
    }
}
