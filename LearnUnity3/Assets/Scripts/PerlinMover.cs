using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinMover : MonoBehaviour
{
    Mover perlinMover;
    
    void Start()
    {
        perlinMover = new Mover();
    }

    
    void FixedUpdate()
    {
        perlinMover.Walk();
    }

    public class Mover
    {
        Vector3 location;
        GameObject introMover = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        private Vector2 minimumPosition, maximumPosition;

        // Range over which height varies.
        float heightScale = .7f;
        float widthScale = .5f;

        // Distance covered per second along X axis of Perlin plane.
        float xScale = .3f;
        float yScale = .5f;

        public Mover()
        {
            FindWindowLimits();
            location = Vector3.zero;
            Renderer renderer = introMover.GetComponent<Renderer>();
            renderer.material = new Material(Shader.Find("Diffuse"));
        }

        void Step()
        {
            location = introMover.transform.position;
            float incrementx = widthScale * Mathf.PerlinNoise(Time.time * xScale, 0.0f);
            float incrementy = heightScale * Mathf.PerlinNoise(0.0f, Time.time * yScale);


            location.x += incrementx;
            location.y += incrementy;
            introMover.transform.position += location;
        }

        void CheckEdges()
        {
            if (location.x > maximumPosition.x)
            {
                location = Vector2.zero;
            }
            else if (location.x < minimumPosition.x)
            {
                location = Vector2.zero;
            }
            if (location.y > maximumPosition.y)
            {
                location = Vector2.zero;
            }
            else if (location.y < minimumPosition.y)
            {
                location = Vector2.zero;
            }
            introMover.transform.position = location;
        }

        void FindWindowLimits()
        {
            Camera.main.orthographic = true;
            minimumPosition = Camera.main.ScreenToWorldPoint(Vector2.zero);
            maximumPosition = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
            //is screentoworldpoint necessary here?
        }

        public void Walk()
        {
            Step();
            //Draw();
            CheckEdges();
        }

        public void Draw()
        {
            List<GameObject> spheres = new List<GameObject>();
            if (spheres.Count < 100)
            {
                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.transform.position = new Vector3(introMover.transform.position.x, introMover.transform.position.y, 0f);
                spheres.Add(sphere);
            }
            else
            {
                spheres.RemoveAt(0);
            }
            
        }

    }
}
