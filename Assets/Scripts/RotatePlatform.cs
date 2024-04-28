using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlatform : MonoBehaviour
{
    public Vector3 rotateChange;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(rotateChange);
    }
}
