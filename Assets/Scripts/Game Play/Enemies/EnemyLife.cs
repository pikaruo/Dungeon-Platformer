using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyLife : MonoBehaviour
{

    [Header("Health Point")]
    private float minHealth = 0; //minimal hp
    [SerializeField] float currentHealth = 10; //mengatur hp saat ini

    [SerializeField] PlayerBullet playerBullet; //untuk mengambil damage bullet

    [SerializeField] Reward reward; //untuk mengambil reward membunuh musuh
    [SerializeField] AudioSource killEnemyAudio; //untuk mengambil suara

    [SerializeField] TMP_Text healthPointText; //untuk text health point

    private void Start()
    {
        healthPointText.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Attack"))
        {
            // jika player bullet mengenai monster maka akan mengurangi health pointnya
            currentHealth -= playerBullet.bulletDamage;
            healthPointText.text = "Total Health : " + currentHealth;

            healthPointText.enabled = true;

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
