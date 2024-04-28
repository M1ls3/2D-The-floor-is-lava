using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public Vector2 finishPos;
    public float moveSpeed;

    private Vector2 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void FixedUpdate()
    {
        float pingPong = Mathf.PingPong(Time.time * moveSpeed, 1);
        Vector2 newPosition = Vector2.Lerp(startPos, finishPos, pingPong);
        transform.position = newPosition;
    }
}
