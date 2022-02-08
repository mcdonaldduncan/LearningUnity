using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [System.NonSerialized] public int health = 3;

    Transform target;
    SpawnManager spawnManager;

    float speed = 3f;

    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        target = GameObject.Find("Dragon").GetComponent<Transform>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        health--;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        
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
