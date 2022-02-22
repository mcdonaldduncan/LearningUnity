using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Utility;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField]float speed = 1f;
    [SerializeField]int health = 3;

    Transform target;
    SpawnManager spawnManager;

    Vector3 windowLimits;

    void Start()
    {
        windowLimits = FindWindowLimits();
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
        if (transform.position.x < -windowLimits.x)
        {
            Destroy(gameObject);
        }
    }
}
