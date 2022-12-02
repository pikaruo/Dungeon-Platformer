using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer sprite;
    private Rigidbody2D rb;

    [SerializeField] AudioSource deathAudio;
    [SerializeField] AudioSource savePointAudio;

    private Vector2 respownPoint;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        respownPoint = transform.position;
    }

    // player mati jika tertabrak musuh
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Enemy"))
        {
            Die();
        }
    }

    // save point
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Save Point"))
        {
            savePointAudio.Play();
            respownPoint = transform.position;
        }
    }

    // fungsi player mati
    private void Die()
    {
        deathAudio.Play();
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    // kembalikan ke check point jika player mati
    private void CheckPoint()
    {
        sprite.flipX = false;
        anim.SetInteger("state", 0);
        rb.bodyType = RigidbodyType2D.Dynamic;
        transform.position = respownPoint;
    }

}
