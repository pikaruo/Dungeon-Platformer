using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToPointMove : MonoBehaviour
{
    [SerializeField] float speed; //speed platform
    [SerializeField] int startingPoint; //location platform start
    [SerializeField] Transform[] points; //array tranform points

    private int currentIndexPoint; //index of array

    private void Start()
    {
        // set pertama kali object bergerak
        transform.position = points[startingPoint].position;
    }

    private void Update()
    {
        // mengecek jarak platform dan point
        if (Vector2.Distance(transform.position, points[currentIndexPoint].position) < 0.1f)
        {
            currentIndexPoint++;
            if (currentIndexPoint == points.Length)
            {
                currentIndexPoint = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, points[currentIndexPoint].position, speed * Time.deltaTime);
    }
}
