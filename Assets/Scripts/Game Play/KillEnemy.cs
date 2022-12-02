using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    [SerializeField] AudioSource killEnemyAudio;

    [SerializeField] ItemCollector itemCollector;

    // musuh mati jika terinjak player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            RewardKillEnemy();
            Destroy(collision.gameObject);
        }
    }

    // fungsi reward jika bunuh musuh
    private void RewardKillEnemy()
    {
        itemCollector.items += 10;
        itemCollector.totalItemText.text = "Items : " + itemCollector.items;
        killEnemyAudio.Play();
    }

}
