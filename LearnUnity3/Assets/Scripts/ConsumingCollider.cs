using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumingCollider : MonoBehaviour
{
    Vector2 velocity;
    Vector2 location;
    float x, y;
    Vector3 windowLimits;

    void Start()
    {
        transform.localScale = Vector3.one * Random.Range(.1f, 5.0f);
        location = transform.position;
        velocity = new Vector2 (Random.Range(-.02f, .02f), Random.Range(-.02f, .02f));
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

    private void OnCollisionEnter(Collision collision)
    {
        if (transform.localScale.magnitude > collision.gameObject.transform.localScale.magnitude)
        {
            Destroy(collision.gameObject);
        }
    }

    void FindWindowLimits()
    {
        Camera.main.orthographic = true;
        windowLimits = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        x = windowLimits.x;
        y = windowLimits.y;
    }

    bool IsSphereCollision(Collision collision)
    {
        ConsumingCollider sphere = collision.gameObject.GetComponent<ConsumingCollider>();
        if (sphere != null)
        {
            return true;
        }
        return false;
    }

    //Roommate Duncan = new Roommate("Duncan", "He/Him/His", "Programming, Reading and Games");

    //public class Roommate
    //{
    //    string name;
    //    string pronouns;
    //    string hobbies;

    //    public Roommate(string n, string p, string h)
    //    {
    //        name = n;
    //        pronouns = p;
    //        hobbies = h;
    //    }
    //}
}
