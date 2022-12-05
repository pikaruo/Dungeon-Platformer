using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float currentTime = 0;
    [SerializeField] TMP_Text currentTimeText;

    private void Update()
    {
        currentTime = currentTime + Time.deltaTime;

        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = "Timer : " + time.ToString(@"mm\:ss");
    }

}
