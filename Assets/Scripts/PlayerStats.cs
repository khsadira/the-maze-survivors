using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public bool safe = true;
    public float current_food = 50f;
    public float max_food = 100f;
    public float food_consumption = 0.1f;

    void Update() {
        if (safe) {
            current_food -= (food_consumption/2)*Time.deltaTime;
        } else {
            current_food -= food_consumption*Time.deltaTime;
        }
    }
}
