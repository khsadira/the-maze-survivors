using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public float food_quantity = 25f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerStats stats = other.GetComponent<PlayerStats>();
            stats.current_food += food_quantity;
            if (stats.current_food > stats.max_food)
            {
                this.food_quantity = stats.current_food - stats.max_food;
                stats.current_food = stats.max_food;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}
