using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMover : MonoBehaviour
{
    Mover mover;

    // Start is called before the first frame update
    void Start()
    {
        mover = new Mover();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        mover.Walk();
    }


    public class Mover
    {
        Vector3 location;
        GameObject intromover = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        Vector2 minimumPosition, maximumPosition;

        public Mover()
        {
            FindWindowLimits();
            location = Vector2.zero;
            Renderer r = intromover.GetComponent<Renderer>();
            r.material = new Material(Shader.Find("Diffuse"));
        }

        void Step()
        {
            location = intromover.transform.position;
            float incrementx = Random.Range(-1, 2);
            float incrementy = Random.Range(-1, 2);
            //random doesnt seem random, always going down to left(-1,-1), using (-1,1)
            location.x += incrementx;
            location.y += incrementy;
            intromover.transform.position += location * Time.deltaTime;
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
            intromover.transform.position = location;
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
            CheckEdges();
        }
    }
}
