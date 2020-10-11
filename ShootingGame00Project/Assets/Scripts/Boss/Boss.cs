using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{

    // Boss体力関連
    private float currentHealth;
    [SerializeField] float perCollision = 20;
    [SerializeField] float startHealth = 1000f;

    public Image healthBar;

    //public GameObject damageExplosion;
    public GameObject dieExplosion;
    //Spaceship spaceship;

    //float offset;
    GameManagement gameManagement;

    // Boss音関連
    //private AudioSource bossAudioSource;
    //public AudioClip bossExplosionSound;


    void Start()
    {

        currentHealth = startHealth;

    }

    // Playerにぶつかるとあたり判定
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") == true)
        {

            currentHealth = currentHealth - perCollision;
            healthBar.fillAmount = currentHealth / 1000f;

            if (currentHealth >= 1)
            {
                //Destroy(collision.gameObject);
                //Explosion();
                Debug.Log(currentHealth);
                //DamageExplosion();
            }
            else if (currentHealth <= 0)
            {
                // Boss の体力が0になると爆発する
                Debug.Log(currentHealth);
                //Destroy(collision.gameObject);
                //Destroy(gameObject);
                DieExplosion();

                FindObjectOfType<GameManagement>().GameClear();
            }

            // Playerと当たった時にもExplosionFXが生成されるように設定
           // gameManagement.AddScore();


        }
        else if (collision.CompareTag("PlayerMissile") == true) 
        {

            currentHealth = currentHealth - perCollision;
            healthBar.fillAmount = currentHealth / 1000f;

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
                Debug.Log(currentHealth);
                Destroy(collision.gameObject);
                Destroy(gameObject);
                DieExplosion();

                FindObjectOfType<GameManagement>().GameClear();
            }

        }
        else if (collision.CompareTag("Enemy") == true)
        {

        }

    }

    /*
    private void DamageExplosion()
    {
        Instantiate(damageExplosion, transform.position, transform.rotation);
    }
    */

    private void DieExplosion()
    {
        Instantiate(dieExplosion, transform.position, transform.rotation);
    }

}
