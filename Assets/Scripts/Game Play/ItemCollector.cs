using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private int items = 0;

    [SerializeField] TMP_Text totalItemText;
    [SerializeField] AudioSource collectAudio;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Item"))
        {
            collectAudio.Play();
            Destroy(collider.gameObject);
            items++;
            totalItemText.text = "Items : " + items;
        }
    }
}
