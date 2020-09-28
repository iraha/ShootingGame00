using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    [SerializeField]
    float speed = 7f;

    void Update()
    {
        transform.position -= new Vector3(0, Time.deltaTime * speed);
        if (transform.position.y <= -40f)
        {
            transform.position = new Vector2(0, 40.0f);
        }
    }
    
}
