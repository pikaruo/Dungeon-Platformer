using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObstacle : MonoBehaviour
{

    [SerializeField] Rigidbody2D obstacle;

    // jika player menyentuh collider akan memicu obstacle
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            obstacle.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
