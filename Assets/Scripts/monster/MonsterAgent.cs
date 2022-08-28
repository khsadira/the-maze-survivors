using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine.UIElements;

public class MonsterAgent : Agent
{
    [SerializeField] GameObject safezone;

    public override void OnEpisodeBegin() {
        transform.position = this.GetComponent<MonsterScripts>().getMonsterStarterPosition(null);
        this.GetComponent<MonsterStats>().player_destroyed = 0;
        this.GetComponent<MonsterStats>().timeAlive = 0f;
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.position);
        sensor.AddObservation(this.safezone.transform.position);

        List<Transform> players = GameObject.Find("GameManager").GetComponent<GameManager>().players;
        for (int i = 0; i < players.Count; i++) {
            sensor.AddObservation(players[i].position);
        }
    }

    public float speed = 10.0f;
    public override void OnActionReceived(ActionBuffers actions)
    {
        this.transform.position = new Vector3(this.transform.position.x + actions.ContinuousActions[0] * Time.deltaTime * speed, this.transform.position.y + actions.ContinuousActions[1] * Time.deltaTime * speed, 0f);
    }
}
