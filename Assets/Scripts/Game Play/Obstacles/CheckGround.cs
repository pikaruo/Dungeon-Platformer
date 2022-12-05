using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{

    [SerializeField] LayerMask layerMask;
    [SerializeField] GameObject trigger;

    // hancurkan object trigger dan object obstacle
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & layerMask) != 0 || collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(trigger);
            Destroy(gameObject);
        }
    }
}
