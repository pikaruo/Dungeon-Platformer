using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillBullet : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] int lifetime = 2;

    private float timer;
    [SerializeField] Rigidbody2D rb;
    private void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > lifetime)
        {
            timer = 0;
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(this.gameObject);
    }
}
