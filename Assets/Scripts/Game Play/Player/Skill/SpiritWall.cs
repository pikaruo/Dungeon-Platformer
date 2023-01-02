using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritWall : MonoBehaviour
{
    enum spiritWallType
    {
        Fire,
        Water,
        Air
    }
    [SerializeField] spiritWallType wallType;
    [SerializeField] SpriteRenderer rend;
    private void Start()
    {
        switch (wallType)
        {
            case spiritWallType.Fire:
                Debug.Log("fire");
                rend.color = Color.red;
                break;
            case spiritWallType.Water:
                Debug.Log("water");
                rend.color = Color.blue;
                break;
            case spiritWallType.Air:
                Debug.Log("air");
                rend.color = Color.white;
                break;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Skill" + wallType))
        {
            Destroy(this.gameObject);
        }
    }
}
