using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{

    private Animator anim;
    private Rigidbody2D rb;

    [SerializeField] ItemCollector itemCollector;

    [SerializeField] AudioSource deathAudio;
    [SerializeField] AudioSource killEnemyAudio;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // player mati jika tertabrak musuh
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Enemy"))
        {
            Die();
        }
    }

    // musuh mati jika terinjak player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            RewardKillEnemy();
            Destroy(collision.gameObject);
        }
    }

    // fungsi player mati
    private void Die()
    {
        deathAudio.Play();
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    // fungsi reward jika bunuh musuh
    private void RewardKillEnemy()
    {
        itemCollector.items += 10;
        itemCollector.totalItemText.text = "Items : " + itemCollector.items;
        killEnemyAudio.Play();
    }

    // ulangi level jika player mati
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
