using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMover : MonoBehaviour
{
    Mover mover;
    int[] numbers = new[] { 1, 1, 2, 3, 3 };

    // Start is called before the first frame update
    void Start()
    {
        mover = new Mover();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        mover.Walk();
        int randomInt = Random.Range(0, numbers.Length);
        Debug.Log(numbers[randomInt]);
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
            Renderer renderer = intromover.GetComponent<Renderer>();
            //Rigidbody rigidbody = intromover.GetComponent<Rigidbody>();
            renderer.material = new Material(Shader.Find("Diffuse"));
        }

        void Step()
        {
            location = intromover.transform.position;
            float incrementx = Random.Range(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            float incrementy = Random.Range(Random.Range(-1f, 1f), Random.Range(-1f, 1f));

            //random doesnt seem random, always going down to left(-1,-1), using (-1,1).
            //Found out I was using an ovld that used max exclusive,
            //exclusive on -1, 1 using int. must specify 1f

            location.x += incrementx * Time.deltaTime;
            location.y += incrementy * Time.deltaTime;
            intromover.transform.position += location;
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
        }

        public void Walk()
        {
            Step();
            //Draw();
            CheckEdges();
        }

        public void Draw()
        {
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.position = new Vector3(intromover.transform.position.x, intromover.transform.position.y, 0f);
        }
    }
}
