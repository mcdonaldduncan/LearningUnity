using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Utility;

public class FireballScript : MonoBehaviour
{
    [SerializeField] float launchForce;

    Rigidbody2D _rigidbody2D;
    SpawnManager spawnManager;

    Vector3 startPosition;
    Vector3 windowLimits;

    bool isFlying;

    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    void Start()
    {
        windowLimits = FindWindowLimits();
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
        if (transform.position.x > windowLimits.x)
        {
            Destroy(gameObject);
        }
        if (transform.position.y > windowLimits.y || transform.position.y < -windowLimits.y)
        {
            Destroy(gameObject);
        }
    }

    
}
