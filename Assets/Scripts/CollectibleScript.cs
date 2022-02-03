using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;
using Random = UnityEngine.Random;


public class CollectibleScript : MonoBehaviour
{
    public float rotationSpeed = 5f;
    public float speed = 2.5f;
    private float maxY, maxZ;
    private float randomdirection;
    private Vector3 currentLocation;


    // Start is called before the first frame update
    void Start()
    {
        maxY = transform.position.y + 5;
        maxZ = transform.position.z + 5;
        randomdirection = Random.Range(1f, 2f);
        currentLocation = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //random Rotation
        float angle = Time.frameCount % 314 / 100f;
        float random = Random.Range(20, 50) * rotationSpeed;
        transform.Rotate(new Vector3(15 + random, 30 + random, 45) * Time.deltaTime);

        
        //move from start spot to other spot in a line
        if (randomdirection <= 1.5f)//move in y Direction
        {
            transform.position = new Vector3(currentLocation.x, Mathf.PingPong(Time.time * speed,maxY), currentLocation.z);
        }
        else
        {
            transform.position = new Vector3(currentLocation.x, currentLocation.y, Mathf.PingPong(Time.time * speed, maxZ));
        }

        //transform.position = startPosition + transform.up * Mathf.Sin(Time.time * frequency + offset) * magnitude;

    }
}
