using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public float speed = 1f;

    // Update is called once per frame
    void Update() {
       Vector3 pos = transform.position;


    
        if (Input.GetKey("w") || Input.GetKey("z")) {
            pos.y += speed * Time.deltaTime;
        } 
        
        if (Input.GetKey("s")) {
            pos.y -= speed * Time.deltaTime;
        }
        
        if (Input.GetKey("q") || Input.GetKey("a")) {
            pos.x -= speed * Time.deltaTime;
        }
        
        if (Input.GetKey("d")) {
            pos.x += speed * Time.deltaTime;
        }

        transform.position = pos;
    }
}
