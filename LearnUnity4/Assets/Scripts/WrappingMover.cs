using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WrappingMover : MonoBehaviour
{
    private Mover mover;

    void Start()
    {
        mover = new Mover();
    }

    void Update()
    {
        mover.Walk();
        mover.CheckLimits();
    }

    class Mover
    {
        private Vector2 location, velocity;
        private Vector3 windowBounds;
        private GameObject mover = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        float x, y;

        public Mover()
        {
            FindWindowLimits();
            location = new Vector2(Random.Range(-windowBounds.x, windowBounds.x), Random.Range(-windowBounds.y, windowBounds.y));
            velocity = new Vector2(Random.Range(-2.0f, 2.0f), Random.Range(-2.0f, 2.0f));
            Renderer r = mover.GetComponent<Renderer>();
            r.material = new Material(Shader.Find("Diffuse"));
        }

        public void Walk()
        {
            location += velocity * Time.deltaTime;
            mover.transform.position = new Vector2(location.x, location.y);
        }

        public void CheckLimits()
        {
            if (location.x > x)
            {
                location.x = -x;
            }
            if (location.x < -x)
            {
                location.x = x;
            }
            if (location.y > y)
            {
                location.y = -y;
            }
            if (location.y < -y)
            {
                location.y = y;
            }
        }

        void FindWindowLimits()
        {
            Camera.main.orthographic = true;
            windowBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
            x = windowBounds.x;
            y = windowBounds.y;
        }

    }


}
