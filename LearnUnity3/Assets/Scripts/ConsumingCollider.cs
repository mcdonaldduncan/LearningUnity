using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumingCollider : MonoBehaviour
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
        //speed = new Vector2(0.1f, 0.1f);
        FindWindowLimits();
    }

    void Update()
    {
        location += velocity;
        transform.position = location;
        if (location.x > x || location.x < -x)
        {
            velocity.x = -velocity.x;
        }
        if (location.y > y || location.y < -y)
        {
            velocity.y = -velocity.y;
        }

    }

    void FindWindowLimits()
    {
        Camera.main.orthographic = true;
        windowLimits = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        x = windowLimits.x - 10f;
        y = windowLimits.y - 1.5f;
    }
}
