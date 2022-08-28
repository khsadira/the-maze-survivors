using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class MlAgent : Agent
{
    [SerializeField] GameObject safezone;
    public override void OnEpisodeBegin()
    {
        transform.localPosition = new Vector3(Random.Range(-40f, 40f), Random.Range(-20f, 20f), 0f);
        this.GetComponent<PlayerStats>().current_food = 50f;
        this.GetComponent<PlayerStats>().timeAlive = 0f;
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.position);
        sensor.AddObservation(this.GetComponent<PlayerStats>().current_food);
        sensor.AddObservation(this.GetComponent<PlayerStats>().timeAlive);
        sensor.AddObservation(this.GetComponent<PlayerStats>().safe);
        sensor.AddObservation(this.safezone.transform.position);
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        base.Heuristic(actionsOut);
    }

    public float speed = 10.0f;
    public override void OnActionReceived(ActionBuffers actions)
    {
        // this.transform.position = new Vector3(this.transform.position.x + actions.ContinuousActions[0] * Time.deltaTime * speed, this.transform.position.y + actions.ContinuousActions[1] * Time.deltaTime * speed, 0f);
    }
}
