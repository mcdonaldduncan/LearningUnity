using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    Rigidbody _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        Respawn();
    }

    void Update()
    {
        if (transform.position.y < -10)
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        float randomX = UnityEngine.Random.Range(-10, 10);
        float randomY = UnityEngine.Random.Range(5, 10);
        transform.position = new Vector3(randomX, randomY);
        _rigidBody.velocity = Vector3.zero;
    }
}
