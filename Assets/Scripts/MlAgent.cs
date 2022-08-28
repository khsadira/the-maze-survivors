using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class MlAgent : Agent
{
    [SerializeField] private GameObject[] cubes;
    public override void OnEpisodeBegin()
    {
        transform.localPosition = new Vector3(Random.Range(-50f, -50f), Random.Range(0f, 0f), 0f);
        this.GetComponent<PlayerStats>().current_food = 50f;
        this.GetComponent<PlayerStats>().timeAlive = 0f;
        //for (int i = 0; i < cubes.Length; i++)
        //{
        //    cubes[i].transform.localPosition = new Vector3(Random.Range(-60f, 60f), Random.Range(-30f, 30f), 0f);
        //}
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(this.GetComponent<PlayerStats>().current_food);
        sensor.AddObservation(this.GetComponent<PlayerStats>().timeAlive);
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<int> discreteActions = actionsOut.DiscreteActions;

        switch (Mathf.RoundToInt(Input.GetAxisRaw("Horizontal")))
        {
            case -1: discreteActions[0] = 2; break;
            case 0: discreteActions[0] = 0; break;
            case 1: discreteActions[0] = 1; break;
        }
        switch (Mathf.RoundToInt(Input.GetAxisRaw("Vertical")))
        {
            case -1: discreteActions[1] = 2; break;
            case 0: discreteActions[1] = 0; break;
            case 1: discreteActions[1] = 1; break;
        }
    }

    public float speed = 10.0f;
    public override void OnActionReceived(ActionBuffers actions)
    {
        Vector3 newPos = this.transform.localPosition;

        switch (actions.DiscreteActions[0])
        {
            case 1: newPos.x += Time.deltaTime * speed; break;
            case 2: newPos.x -= Time.deltaTime * speed; break;
        }
        switch (actions.DiscreteActions[1])
        {
            case 1: newPos.y += Time.deltaTime * speed; break;
            case 2: newPos.y -= Time.deltaTime * speed; break;
        }
        this.transform.localPosition = newPos;
    }
}
