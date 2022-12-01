using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{

    [SerializeField] Finish finish;

    [HideInInspector] public int items = 0;
    [SerializeField] int minimumCollectItems;

    [HideInInspector] public TMP_Text totalItemText;
    [SerializeField] AudioSource collectAudio;

    private void Update()
    {
        // syarat object finish dimunculkan
        if (items >= minimumCollectItems)
        {
            finish.gameObject.SetActive(true);
        }
    }

    // player mengumpulkan items
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
