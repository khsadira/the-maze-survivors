using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safezone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            other.gameObject.GetComponent<PlayerStats>().safe = true;
            other.gameObject.GetComponent<MlAgent>().AddReward(2500f);
            other.gameObject.GetComponent<MlAgent>().EndEpisode();
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player") {
            other.gameObject.GetComponent<PlayerStats>().safe = false;
        }
    }
}
