using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public bool safe = true;
    public float current_food = 50f;
    public float max_food = 100f;
    public float food_consumption = 0.05f;

    void Update() {
        current_food -= food_consumption*Time.deltaTime;
    }
}
