using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject Players;
    [SerializeField] GameObject Monsters;

    public float bestTime = 0.0f;
    public Camera mainCamera;

    public List<Transform> players = new List<Transform>();
    public List<Transform> monsters = new List<Transform>();
    
    void Start() {
        Physics2D.IgnoreLayerCollision(6, 6);
        FeedPlayers();
        FeedMonsters();
    }

    void Update() {
        FeedPlayers();
        FeedMonsters();
    }

    public void FeedPlayers() {
        for (int i = 0; i < Players.transform.childCount; i++) {
            this.players.Add(Players.transform.GetChild(i));
        }
    }

    public void FeedMonsters() {
        for (int i = 0; i < Monsters.transform.childCount; i++) {
            this.monsters.Add(Monsters.transform.GetChild(i));
        }
    }
}
