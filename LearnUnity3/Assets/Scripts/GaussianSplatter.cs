using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaussianSplatter : MonoBehaviour
{
    [SerializeField] int splatterCount = 1000;

    List<Splatter> splatters = new List<Splatter>();

    private void Awake()
    {

    }

    void FixedUpdate()
    {
        Splat();
        //Shade();
    }

    void Splat()
    {
        
        if (splatters.Count < splatterCount)
        {


            Splatter splatter = new Splatter();
            splatters.Add(splatter);
        }
        //gameObject.AddComponent(typeof(Splatter)) as Splatter;
    }

    void Shade()
    {
        foreach (var splatter in splatters)
        {
            float x1 = splatter.@object.transform.position.x;
            float y1 = splatter.@object.transform.position.y;
            foreach (var splatterb in splatters)
            {
                float x2 = splatterb.@object.transform.position.x;
                float y2 = splatterb.@object.transform.position.y;
                if (x1 > x2 - .5f && x1 < x2 + .5f && y1 > y2 - .5f && y1 < y2 + .5f)
                {
                    splatter.renderer.material.color = new Color(x1, y1, 0);
                }
            }
            //performance yikes for obvious reasons, DNU
           
        }
    }


    public class Splatter
    {
        
        public GameObject @object = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        SphereCollider collider;
        Rigidbody rb;
        public Renderer renderer;
        public int collisionCounter;
        Vector3 location;
        float x;
        float y;
        Vector2 windowBounds;

        public Splatter()
        {
            FindWindowLimits();
            @object.transform.position = GaussianVector(x, y);
            location = @object.transform.position;
            @object.AddComponent<Rigidbody>();
            renderer = @object.GetComponent<Renderer>();
            rb = @object.GetComponent<Rigidbody>();
            rb.isKinematic = true;
            //rb.transform.position = location;
            collider = @object.GetComponent<SphereCollider>();
            //collider.center = location;
            //collider.isTrigger = true;
            collider.radius = 1;
            renderer.material = new Material(Shader.Find("Diffuse"));
            
        }

        //private void OnCollisionEnter(Collision collision)
        //{
        //    collisionCounter += 25;
        //    Debug.Log("Collision Detected");
            
        //}

        Vector3 GaussianVector(float width, float height)
        {
            var gaussianVector = new Vector3(Random.Range(Random.Range(-width, width), Random.Range(-width, width)), Random.Range(Random.Range(-height, height), Random.Range(-height, height)), 0f);
            return gaussianVector;
        }

        void FindWindowLimits()
        {
            Camera.main.orthographic = true;
            windowBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
            x = windowBounds.x;
            y = windowBounds.y;
        }

    }

    //unused
    float montecarlo()
    {
        while (true)
        {
            float r1 = Random.value;
            float probability = r1;
            float r2 = Random.value;

            if (r2 < probability)
            {
                return r1;
            }

        }
    }

}
