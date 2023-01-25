using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorTests : MonoBehaviour
{
    [SerializeField] Vector2 velocity;
    Vector2 location;
    float x, y;
    Vector3 windowLimits;

    void Start()
    {
        transform.position = Vector3.zero;
        transform.localScale = Vector3.one * 1.5f;
        location = transform.position;
        FindWindowLimits();
    }

    void Update()
    {
        transform.position += (Vector3)velocity * Time.deltaTime;

        if (transform.position.x > x)
        {
            velocity.x = -velocity.x;
            transform.position = new Vector3(x, transform.position.y, 0);
        }
        if (transform.position.x < -x)
        {
            velocity.x = -velocity.x;
            transform.position = new Vector3(-x, transform.position.y, 0);
        }
        if (transform.position.y > y)
        {
            velocity.y = -velocity.y;
            transform.position = new Vector3(transform.position.x, y, 0);
        }
        if (transform.position.y < -y)
        {
            velocity.y = -velocity.y;
            transform.position = new Vector3(transform.position.x, -y, 0);
        }
    }



    void FindWindowLimits()
    {
        Camera.main.orthographic = true;
        windowLimits = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        x = windowLimits.x - 6f;
        y = windowLimits.y - 1f;
    }
}
