using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GensokuDan : MonoBehaviour
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
        v = 0.98f * v;
        // 5.0 より遅ければ，5.0 で上書き
        if (v.magnitude < 5.0f)
        {
            v = v.normalized * 5.0f;
        }
        GetComponent<Rigidbody2D>().velocity = v;
    }
}
