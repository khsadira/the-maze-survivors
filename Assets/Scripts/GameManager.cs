using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float bestTime = 0.0f;
    public Camera mainCamera;

    void Start()
    {
        Physics2D.IgnoreLayerCollision(6, 6);
    }
}
