using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{

    public float bulletDamage = 1; //damage bullet

    [SerializeField] float speed = 10f; //kecepatan bullet
    [SerializeField] int lifetime = 2; //masa hidup bullet

    private float timer; //mengatur waktu
    [SerializeField] Rigidbody2D rb;
    [SerializeField] LayerMask layerMask;
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

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (((1 << collider.gameObject.layer) & layerMask) != 0 || collider.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
