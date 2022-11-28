using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField] float speed; //speed platform
    [SerializeField] int startingPoint; //location platform start
    [SerializeField] Transform[] points; //array tranform points

    private int i; //index of array

    private void Start()
    {
        /*
        setting the starting position platform using index startingPoint
        */
        transform.position = points[startingPoint].position;
    }

    private void Update()
    {
        // checking distance of the platform and the point
        if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++;
            if (i == points.Length)
            {
                i = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }
}
