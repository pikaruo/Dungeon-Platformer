using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatformer : MonoBehaviour
{

    // if player on platform, player follow platform
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.transform.SetParent(null);
        }
        else
        {
            collision.transform.SetParent(transform);
        }
    }

    // if player not on platform not follow platform
    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.transform.SetParent(null);
    }

}
