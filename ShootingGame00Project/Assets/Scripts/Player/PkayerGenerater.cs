using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PkayerGenerater : MonoBehaviour
{

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(player, transform.position, transform.rotation);
    }
    
}
