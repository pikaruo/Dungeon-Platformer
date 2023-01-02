using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerSkill : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] TMP_Text cooldownText;
    [SerializeField] GameObject skillFirePrefab;
    [SerializeField] GameObject skillWaterPrefab;
    [SerializeField] GameObject skillAirPrefab;
    [SerializeField] float maxCooldownTime = 4;
    float cooldownTime;

    private void Update()
    {
        cooldownText.text = "Cooldown : " + (int)cooldownTime;
        cooldownTime -= Time.deltaTime;
        cooldownTime = Mathf.Clamp(cooldownTime, 0, 5);

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (cooldownTime <= 0)
            {
                Debug.Log("ShootFire");
                ShootFire();
                cooldownTime = maxCooldownTime;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (cooldownTime <= 0)
            {
                Debug.Log("ShootWater");
                ShootWater();
                cooldownTime = maxCooldownTime;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (cooldownTime <= 0)
            {
                Debug.Log("ShootAir");
                ShootAir();
                cooldownTime = maxCooldownTime;
            }
        }
    }

    private void ShootFire()
    {
        Instantiate(skillFirePrefab, firePoint.position, firePoint.rotation);
    }
    private void ShootWater()
    {
        Instantiate(skillWaterPrefab, firePoint.position, firePoint.rotation);
    }
    private void ShootAir()
    {
        Instantiate(skillAirPrefab, firePoint.position, firePoint.rotation);
    }
}
