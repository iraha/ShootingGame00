using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Enemy体力関連
    private float currentHealth;
    [SerializeField] float perCollision = 20;
    [SerializeField] float startHealth = 100f;

    public GameObject dieExplosion;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startHealth;
    }

    // Update is called once per frame
    // Playerにぶつかるとあたり判定
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") == true)
        {

            currentHealth = currentHealth - perCollision;


            if (currentHealth >= 1)
            {
                //Destroy(collision.gameObject);
                //Explosion();
            }
            else if (currentHealth <= 0)
            {
                // Boss の体力が0になると爆発する
                Debug.Log(currentHealth);
                Destroy(collision.gameObject);
                Destroy(gameObject);
                DieExplosion();

            }

            // Playerと当たった時にもExplosionFXが生成されるように設定
            // gameManagement.AddScore();


        }
        else if (collision.CompareTag("PlayerMissile") == true)
        {

            currentHealth = currentHealth - perCollision;


            if (currentHealth >= 1)
            {
                //Destroy(collision.gameObject);
                //Explosion();
                //Debug.Log(currentHealth);
                //DamageExplosion();
            }
            else if (currentHealth <= 0)
            {
                // Boss の体力が0になると爆発する
                //Debug.Log(currentHealth);
                Destroy(collision.gameObject);
                Destroy(gameObject);
                DieExplosion();

                //FindObjectOfType<GameManagement>().GameClear();
            }


        }
        else if (collision.CompareTag("Enemy") == true)
        {

        }

    }

    private void DieExplosion()
    {
        Instantiate(dieExplosion, transform.position, transform.rotation);
    }


}
