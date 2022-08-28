using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideWall : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag) {
            case "Player":
                other.GetComponent<PlayerStats>().Destroyer();
                break;
            case "Monster":
                other.GetComponent<MonsterScripts>().Destroyer();
                break;
        }
    }
}
