using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : MonoBehaviour
{
    [SerializeField] float launchForce;

    Rigidbody2D _rigidbody2D;
    SpawnManager spawnManager;

    Vector3 startPosition;

    bool isFlying;

    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    void Start()
    {
        startPosition = _rigidbody2D.position;
        _rigidbody2D.isKinematic = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Launch();
        }
        CheckLimits();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    void Launch()
    {
        Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (mp.x > startPosition.x && !isFlying)
        {
            Vector3 launchDirection = mp - startPosition;
            launchDirection.Normalize();
            _rigidbody2D.isKinematic = false;
            _rigidbody2D.AddForce(launchDirection * launchForce);
            isFlying = true;
            spawnManager.isFireballPresent = false;
        }
    }

    void CheckLimits()
    {
        if (transform.position.x > spawnManager.windowLimits.x)
        {
            Destroy(gameObject);
        }
        if (transform.position.y > spawnManager.windowLimits.y || transform.position.y < -spawnManager.windowLimits.y)
        {
            Destroy(gameObject);
        }
    }

    
}
