using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public float speed = 10f;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        pos.x += Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        pos.y += Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.position = pos;
    }
}
