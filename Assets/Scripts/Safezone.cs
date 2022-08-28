using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safezone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        switch (other.tag) {
            case "Player":
                other.gameObject.GetComponent<PlayerStats>().safe = true;
                break;
            case "Monster":
                other.gameObject.GetComponent<MonsterScripts>().Destroyer();
                break;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player") {
            other.gameObject.GetComponent<PlayerStats>().safe = false;
        }
    }
}
