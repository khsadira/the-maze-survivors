using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterScripts : MonoBehaviour
{
    
    [SerializeField] GameObject startZoneLU;
    [SerializeField] GameObject startZoneLD;
    [SerializeField] GameObject startZoneRU;
    [SerializeField] GameObject startZoneRD;

    private GameManager gameManager;
    private MonsterAgent monsterAgent;

    void Start() {
        monsterAgent = this.GetComponent<MonsterAgent>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        this.transform.position = getMonsterStarterPosition(null);
    }

    void Update() {
        this.GetComponent<MonsterStats>().timeAlive += Time.deltaTime;

        if (this.GetComponent<MonsterStats>().player_destroyed == 3) {
            monsterAgent.AddReward(500);
            Destroyer();
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            monsterAgent.AddReward(100);
            this.GetComponent<MonsterStats>().player_destroyed++;
            other.GetComponent<PlayerStats>().current_food -= 50f;
            Debug.Log("MIAM: " + (this.GetComponent<MonsterStats>().player_destroyed).ToString());
        }
    }

    public Vector3 getMonsterStarterPosition(GameObject startZone) {
        if (startZone == null) {
            switch ((int)Random.Range(1, 4)) {
                case 1:
                    startZone = startZoneLU;
                    break;
                case 2:
                    startZone = startZoneLD;
                    break;
                case 3:
                    startZone = startZoneRU;
                    break;
                case 4:
                    startZone = startZoneRD;
                    break; 
            }
        }

        return startZone.transform.position;
    }

    public void Destroyer() {
        monsterAgent.AddReward(this.GetComponent<MonsterStats>().timeAlive * 10);
        monsterAgent.EndEpisode();
        // Destroy(this.gameObject);
        gameManager.FeedMonsters();
    }
}
