using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject Players;
    [SerializeField] GameObject Monsters;
    // [SerializeField] GameObject MazeWalls;

    public float bestTime = 0.0f;
    public Camera mainCamera;

    public List<Transform> players;
    public List<Transform> monsters;
    // public List<Transform> mazeWalls;
    // public List<Transform> hiddenMazeWalls;
    // public List<Transform> centerMazeWalls;
    // public List<Transform> hiddenCenterMazeWalls;


    void Start() {
        Physics2D.IgnoreLayerCollision(6, 6);
        FeedPlayers();
        FeedMonsters();
        // FeedMazeWalls();
        // InvokeRepeating("MoveWalls", 15f, 15f);
    }

    public void FeedPlayers() {
        this.players = new List<Transform>();

        if (Players) {
            for (int i = 0; i < Players.transform.childCount; i++) {
                this.players.Add(Players.transform.GetChild(i));
            }
        }
    }

    public void FeedMonsters() {
        this.monsters = new List<Transform>();

        if (Monsters) {
            for (int i = 0; i < Monsters.transform.childCount; i++) {
                this.monsters.Add(Monsters.transform.GetChild(i));
            }
        }
    }

    // public void FeedMazeWalls() {
    //     this.mazeWalls = new List<Transform>();
    //     this.hiddenMazeWalls = new List<Transform>();
    //     this.centerMazeWalls = new List<Transform>();
    //     this.hiddenCenterMazeWalls = new List<Transform>();

    //     if (MazeWalls) {
    //         for (int i = 0; i < this.MazeWalls.transform.childCount; i++) {
    //             Transform MazeWall = this.MazeWalls.transform.GetChild(i);

    //             if (MazeWall.transform.gameObject.GetComponent<MazeWall>().isNearCenter) {
    //                 if (MazeWall.transform.gameObject.activeSelf) {
    //                     this.centerMazeWalls.Add(MazeWalls.transform.GetChild(i));
    //                 } else {
    //                     this.hiddenCenterMazeWalls.Add(MazeWalls.transform.GetChild(i));
    //                 }
    //             } else {
    //                 if (MazeWall.transform.gameObject.activeSelf) {
    //                     this.mazeWalls.Add(MazeWalls.transform.GetChild(i));
    //                 } else {
    //                     this.hiddenMazeWalls.Add(MazeWalls.transform.GetChild(i));
    //                 }
    //             }

    //         }
    //     }
    // }

    // public void MoveWalls() {
    //     RemoveHiddenWalls(this.centerMazeWalls, this.hiddenCenterMazeWalls, this.hiddenCenterMazeWalls.Count);
        
    //     if (centerMazeWalls.Count > 0) {
    //         List<int> randomNumbers = getRandonNumbers(0, this.centerMazeWalls.Count, (int)(this.centerMazeWalls.Count/3));

    //         AddHiddenWalls(this.centerMazeWalls, this.hiddenCenterMazeWalls, randomNumbers);
    //     }
    // }

    // public void AddHiddenWalls(List<Transform> mazeWalls, List<Transform> hiddenMazeWalls, List<int> AddHiddenWallsIndex) {
    //     AddHiddenWallsIndex.ForEach(delegate(int AddHiddenWallIndex) {
    //         mazeWalls[AddHiddenWallIndex].gameObject.SetActive(false);
    //         hiddenMazeWalls.Add(mazeWalls[AddHiddenWallIndex]);
    //         mazeWalls.RemoveAt(AddHiddenWallIndex);
    //     });
    // }

    // public void RemoveHiddenWalls(List<Transform> mazeWalls, List<Transform> hiddenMazeWalls, int removedHiddenCount) {
    //     for (int i = 0; i < removedHiddenCount; i++) {
    //         hiddenMazeWalls[i].gameObject.SetActive(true);
    //         mazeWalls.Add(hiddenMazeWalls[i]);
    //         hiddenMazeWalls.RemoveAt(i);
    //     }
    // }

    // private List<int> getRandonNumbers(int start, int end, int count) {
    //     List<int> ret = new List<int>();
    //     int i = 0;

    //     while (i < count) {
    //         int random = Random.Range(start, end);

    //         if (ret.Contains(random)) {
    //             continue;
    //         }

    //         ret.Add(random);
    //         i++;
    //     }

    //     return ret;
    // }
}
