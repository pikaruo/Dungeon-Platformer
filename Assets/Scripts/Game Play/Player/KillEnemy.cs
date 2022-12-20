using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{

    [SerializeField] RewardKill rewardKill;
    [SerializeField] AudioSource killEnemyAudio;

    // musuh mati jika terinjak player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            rewardKill.RewardKillEnemy();
            killEnemyAudio.Play();
            Destroy(collision.gameObject);
        }
    }
}
