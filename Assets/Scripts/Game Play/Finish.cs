using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{

    [SerializeField] AudioSource finishSound;

    private bool levelComplate = false;

    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    // selesai stage
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player") && !levelComplate)
        {
            finishSound.Play();
            levelComplate = true;
            Invoke("CompleteLevel", 1f);
        }
    }

    // berpindah scene jika selesai stage
    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
