using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;
using MLAgents.CommunicatorObjects;

public class BotAgent : MonoBehaviour
{
    PlayerStats playerStats;
    Vector3 startingPos;

    void Awake() {
        playerStats = GetComponent<PlayerStats>();
        startingPos = this.transform.position;
    }

    public void AgentReset() {
        base.AgentReset();

        playerStats.transform.position = startingPos;
        playerStats.current_food = 50;
    }

    public void OnReachFood(int number) {
        this.AddReward(number);
    }

    public override void CollectObservation(VectorSensor sensor) {
        AddVectorObs(playerStats.safe);
        AddVectorObs(playerStats.current_food);

        base.CollectObservation();
    }
}
