using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Image healthBar;
    public Vector3 offset;

    private EnemyLife enemyLife;

    private void Start()
    {
        healthBar = GetComponent<Image>();
        enemyLife = FindObjectOfType<EnemyLife>();
    }

    private void Update()
    {
        healthBar.color = Color.Lerp(Color.red, Color.green, healthBar.fillAmount);

        healthBar.fillAmount = enemyLife.currentHealth / enemyLife.maxHealth;
    }
}
