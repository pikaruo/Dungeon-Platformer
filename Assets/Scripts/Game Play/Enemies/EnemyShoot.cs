using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bullet;

    [SerializeField] float startingShoot;

    private float timeShoot;

    private void Start()
    {
        timeShoot = startingShoot;
    }

    private void Update()
    {
        if (timeShoot <= 0)
        {
            Instantiate(bullet, firePoint.position, firePoint.rotation);
            timeShoot = startingShoot;
        }
        else
        {
            timeShoot -= Time.deltaTime;
        }
    }
}
