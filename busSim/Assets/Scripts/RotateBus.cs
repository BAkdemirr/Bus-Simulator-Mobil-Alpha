using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBus : MonoBehaviour
{

    private float rotationSpeed = 20f;

    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
