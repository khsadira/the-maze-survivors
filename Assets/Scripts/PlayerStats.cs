using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public bool safe = true;
    public float current_food = 50f;
    public float max_food = 100f;
    public float food_consumption = 0.05f;
    public float timeAlive = 0.0f;
    public GameManager gameManager;

    private MlAgent mlAgent;

    void Start()
    {
        mlAgent = this.GetComponent<MlAgent>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        timeAlive += Time.deltaTime;
        if (safe)
        {
            current_food -= (food_consumption / 2) * Time.deltaTime;
        }
        else
        {
            current_food -= food_consumption * Time.deltaTime;
        }
        if (current_food <= 0)
        {
            if (timeAlive > 126f)
                mlAgent.AddReward(timeAlive);
            else
                mlAgent.AddReward(-100f);
            if (gameManager.bestTime < timeAlive)
            {
                gameManager.bestTime = timeAlive;
                Debug.Log(timeAlive);
            }
            mlAgent.EndEpisode();
        }
    }
}
