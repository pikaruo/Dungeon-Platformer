using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class Coin : MonoBehaviour
{

    public Tilemap coin;

    private void Start()
    {
        coin = GetComponent<Tilemap>();
    }

    // private void OnTriggerEnter2D(Collider2D collider)
    // {
    //     if (collider.gameObject.CompareTag("Player"))
    //     {
    //         Vector2 hitPosition = Vector2.zero;

    //         foreach (ContactPoint2D hit in collider.ClosestPoint)
    //         {
    //             Debug.Log("Halo");
    //             hitPosition.x = hit.point.x + 2 * hit.normal.x;
    //             hitPosition.y = hit.point.y + 2 * hit.normal.y;
    //             coin.SetTile(coin.WorldToCell(hitPosition), null);
    //         }
    //     }
    // }

    // private void OnCollisionEnter2D(Collision2D collision)
    // {

    // }



    public Vector3 location;

    public void OnDrawGizmos()
    {
        var collider = GetComponent<Collider>();

        if (!collider)
        {
            return; // nothing to do without a collider
        }

        Vector3 closestPoint = collider.ClosestPoint(location);

        Gizmos.DrawSphere(location, 0.1f);
        Gizmos.DrawWireSphere(closestPoint, 0.1f);
    }

}
