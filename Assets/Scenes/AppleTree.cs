using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]

    // Prefab for instantiating apples.
    public GameObject applePrefab;

    // Speed at which the AppleTree moves.
    public float speed = 1f;

    // Distance where AppleTree turns around.
    public float leftAndRightEdge = 10f;

    // Chance that the AppleTree will change direction.
    public float changeDirChance = 0.1f;

    // Desconds between Apples instantiations.
    public float appleDropDelay = 1f;

    // Start is called before the first frame update
    void Start()
    {
        // Start dropping apples.
        //
    }

    // Update is called once per frame
    void Update()
    {
        // Basic Movement.
        Vector3 pos = transform.position;

        pos.x += speed * Time.deltaTime;

        transform.position = pos;

        // Changing Direction
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); // Move right.
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); // Move left.
        }
    }

    // Called 50 times per second.
    void FixedUpdate() 
    {
        if (Random.value < changeDirChance)
        {
            speed *= -1; // Change direction.
        }
    }
}
