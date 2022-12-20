using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{

    [SerializeField] Reward reward;
    [SerializeField] AudioSource killEnemyAudio;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Attack") || collider.gameObject.CompareTag("Player"))
        {
            reward.RewardKillEnemy();
            killEnemyAudio.Play();
            Debug.Log("Halo gys");
            Destroy(gameObject);
        }
    }
}
