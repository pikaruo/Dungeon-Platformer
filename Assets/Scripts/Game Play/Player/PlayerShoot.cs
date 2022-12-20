using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    [SerializeField] int maxAmmo = 10, currentAmmo;

    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] TMP_Text totalAmmo;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (currentAmmo > 0)
            {
                Shoot();
                currentAmmo--;
            }
        }
        totalAmmo.text = $"Ammo : {currentAmmo}/{maxAmmo}";
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
