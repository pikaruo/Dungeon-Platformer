using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyLife : MonoBehaviour
{

    [Header("Health Point")]
    public float maxHealth = 10; //minimal hp
    public float currentHealth; //mengatur hp saat ini

    [SerializeField] PlayerBullet playerBullet; //untuk mengambil damage bullet
    [SerializeField] HealthBar healthBar; //fungsi health bar

    [SerializeField] Reward reward; //untuk mengambil reward membunuh musuh
    [SerializeField] AudioSource killEnemyAudio; //untuk mengambil suara

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Attack"))
        {
            // jika player bullet mengenai monster maka akan mengurangi health pointnya
            currentHealth -= playerBullet.bulletDamage;

            // jika jumlah health point enemy kurang dari atau sama dengan minimal health maka akan dihancurkan
            if (currentHealth <= 0)
            {
                reward.RewardKillEnemy();
                killEnemyAudio.Play();
                Destroy(gameObject);
            }
        }
    }
}
