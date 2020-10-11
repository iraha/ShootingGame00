using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{

    public GameObject enemys;

    public float spawnTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Spawn", spawnTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Spawn()
    {
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        Instantiate(enemys, spawnPosition, transform.rotation);
    }


}
