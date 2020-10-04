using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMissile : MonoBehaviour
{

    [SerializeField] float speed = 20f;

    //public GameObject explosion;

    //GameManagement gameManagement;


    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed;

        //transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
        Destroy(gameObject, 5f);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Enemy") == true)
        {
            //Destroy(collision.gameObject);
            //Explosion();
            Destroy(gameObject);
            //FindObjectOfType<GameManagement>().AddScore();

        }

    }

    /*
    public void Explosion()
    {
        Instantiate(explosion, transform.position, transform.rotation);
    }
    */

}
