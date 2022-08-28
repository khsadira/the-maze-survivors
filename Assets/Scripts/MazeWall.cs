using System.Collections.Generic;
using UnityEngine;

public class MazeWall : MonoBehaviour
{
    public GameObject wall;
    public int mapSize = 24;
    public int starterPos = 0;
    private List<List<GameObject>> wallsV = new List<List<GameObject>>();
    private List<List<GameObject>> wallsH = new List<List<GameObject>>();

    void Start() {
        GenerateWalls();
    }

    private void GenerateWalls() {
        for (int i = 0; i < mapSize; i++) {
            wallsV.Add(new List<GameObject>());
            wallsH.Add(new List<GameObject>());


            for (int j = 0; j < mapSize; j++) {
                wallsV[i].Add(Instantiate(wall, new Vector3(starterPos + (i * 10), starterPos + (j * 10), 0), Quaternion.identity));
                wallsV[i][j].name = "wallV" + i.ToString() + j.ToString();

                wallsH[i].Add(Instantiate(wall, new Vector3(starterPos + (i * 10), starterPos + (j * 10), 0), Quaternion.identity));
                wallsH[i][j].name = "wallH" + i.ToString() + j.ToString();
                wallsH[i][j].transform.localScale = new Vector3(12, 2, 1);
            }
        }
    }
}
