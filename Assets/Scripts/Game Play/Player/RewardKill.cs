using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardKill : MonoBehaviour
{
    [SerializeField] ItemCollector itemCollector;

    // fungsi reward jika bunuh musuh
    public void RewardKillEnemy()
    {
        itemCollector.items += 10;
        itemCollector.totalItemText.text = "Items : " + itemCollector.items;
    }
}
