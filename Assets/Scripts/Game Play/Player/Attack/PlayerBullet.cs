using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] int lifetime = 2;

    private float timer;
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
        // if (collider.gameObject.CompareTag("Enemy"))
        // {
        //     Destroy(collider.gameObject);
        // }
        if (((1 << collider.gameObject.layer) & layerMask) != 0 || collider.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
