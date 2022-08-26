using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public float food_quantity = 25f;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            other.gameObject.GetComponent<PlayerStats>().current_food += food_quantity;
            other.GetComponent<BotAgent>().OnReachFood(food_quantity);
            Destroy(this.gameObject);
        }
    }
}
