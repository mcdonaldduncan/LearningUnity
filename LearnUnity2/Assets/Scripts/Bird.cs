using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] float _launchForce = 500;
    [SerializeField] float _maxDragDistance = 5;

    Vector2 _startPosition;
    Rigidbody2D _rigidbody2D;
    SpriteRenderer _spriteRenderer;
    bool _isFlying;
    float _startOrientation;

    //Caching
    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        _startOrientation = _rigidbody2D.rotation;
        _startPosition = _rigidbody2D.position;
        _rigidbody2D.isKinematic = true;
    }

    void OnMouseDown()
    {
        _spriteRenderer.color = Color.red;
    }

    void OnMouseUp()
    {
        var currentPosition = _rigidbody2D.position;
        Vector2 direction = _startPosition - currentPosition;
        direction.Normalize();

        _rigidbody2D.isKinematic = false;
        _rigidbody2D.AddForce(direction * _launchForce);
        _isFlying = true;
        _rigidbody2D.freezeRotation = false;
        _spriteRenderer.color = Color.white;
    }

    void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 desiredPosition = mousePosition;

        float distance = Vector2.Distance(desiredPosition, _startPosition);
        if (distance > _maxDragDistance)
        {
            Vector2 direction = desiredPosition - _startPosition;
            direction.Normalize();
            desiredPosition = _startPosition + (direction * _maxDragDistance);
        }

        if (desiredPosition.x > _startPosition.x)
            desiredPosition.x = _startPosition.x;

        _rigidbody2D.position = desiredPosition;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_isFlying)
            {
                BirdDive();
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_isFlying)
            {
                //BirdExplode();
            }
        }
    }

    void BirdExplode()
    {
        //needs implementation
        var currentPosition = _rigidbody2D.position;
        //Create 6 new game objects, launch at 360, 300, 240, 180, 120, 60 degree angles
        //Set bird inactive
        StartCoroutine(ResetAfterDelay(5));
    }

    void BirdDive()
    {
        _rigidbody2D.AddForce(Vector2.down * _launchForce);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(ResetAfterDelay(3));        
    }

    IEnumerator ResetAfterDelay(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        _rigidbody2D.position = _startPosition;
        _rigidbody2D.isKinematic = true;
        _rigidbody2D.velocity = Vector2.zero;
        _rigidbody2D.rotation = _startOrientation;
        _rigidbody2D.freezeRotation = true;
        _isFlying = false;

    }

    
}
