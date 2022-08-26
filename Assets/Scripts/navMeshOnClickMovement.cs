using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navMeshOnClickMovement : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    void Start()
    {
        this.navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            this.navMeshAgent.Move(Input.mousePosition);
        }
    }
}
