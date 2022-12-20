using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseTriggerFlyingEnemy : MonoBehaviour
{
    public FlyingEnemy[] enemyArray;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (FlyingEnemy enemy in enemyArray)
            {
                enemy.isChasing = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (FlyingEnemy enemy in enemyArray)
            {
                enemy.isChasing = false;
            }
        }
    }
}
