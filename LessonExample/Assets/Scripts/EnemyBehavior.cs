using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    Transform target;
    SpawnManager spawnManager;

    float speed = 1f;

    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        target = GameObject.Find("Dragon").GetComponent<Transform>();
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        if (transform.position.x < -spawnManager.windowLimits.x)
        {
            Destroy(gameObject);
        }
    }
}
