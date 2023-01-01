using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyLife : MonoBehaviour
{

    [Header("Health Point")]
    private float minHealth = 0; //minimal hp
    [SerializeField] float currentHealth = 10; //mengatur hp saat ini
    [SerializeField] int hideTextTime = 2; //mengatur waktu kapan text health point dihilangkan

    [SerializeField] PlayerBullet playerBullet; //untuk mengambil damage bullet
    [SerializeField] EnemyPatrol enemyPatrol; //untuk mengambil flip patrol

    [SerializeField] Reward reward; //untuk mengambil reward membunuh musuh
    [SerializeField] AudioSource killEnemyAudio; //untuk mengambil suara
    [SerializeField] TMP_Text healthPointText; //untuk text health point

    private float timer;


    private void Start()
    {
        healthPointText.enabled = true; // menghilangkan text health point diawal
    }

    private void Update()
    {

        // if ( == 180)
        // {
        // healthPointText.transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        //     healthPointText.transform.Rotate(0, -180, 0);
        // }
        // else if (enemyPatrol.enemySpeed < 0f)
        // {
        // healthPointText.transform.localScale = new Vector2(transform.localScale.x * 1, transform.localScale.y);
        //     healthPointText.transform.Rotate(0, 180, 0);
        // }

        // mengatur waktu untuk menghilangkan text
        timer += Time.deltaTime;
        if (timer >= hideTextTime)
        {
            healthPointText.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Attack"))
        {
            // jika player bullet mengenai monster maka akan mengurangi health pointnya
            currentHealth -= playerBullet.bulletDamage;
            healthPointText.text = "Total Health : " + currentHealth;

            healthPointText.enabled = true;
            timer = 0;

            // jika jumlah health point enemy kurang dari atau sama dengan minimal health maka akan dihancurkan
            if (currentHealth <= minHealth)
            {
                reward.RewardKillEnemy();
                killEnemyAudio.Play();
                Destroy(gameObject);
            }
        }
    }
}
