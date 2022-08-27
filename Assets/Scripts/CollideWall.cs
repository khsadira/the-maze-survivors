using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideWall : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerStats>().current_food -= 50f;
            other.GetComponent<MlAgent>().AddReward(-250f);
        }
    }
}
