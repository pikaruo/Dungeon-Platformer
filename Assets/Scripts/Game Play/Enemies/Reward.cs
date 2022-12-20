using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reward : MonoBehaviour
{
    [SerializeField] ItemCollector itemCollector;

    // fungsi reward jika bunuh musuh
    public void RewardKillEnemy()
    {
        itemCollector.items += 10;
        itemCollector.totalItemText.text = "Items : " + itemCollector.items;
    }
}
