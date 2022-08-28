using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        switch (other.tag) {
            case "Monster":
                other.gameObject.GetComponent<MonsterStats>().hidden = true;
                break;
            case "Player":
                other.gameObject.GetComponent<PlayerStats>().Destroyer();
                break;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Monster") {
            other.gameObject.GetComponent<MonsterStats>().hidden = false;
        }
    }
}
