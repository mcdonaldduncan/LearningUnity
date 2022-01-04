using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaussianSplatter : MonoBehaviour
{
    [SerializeField] int splatterCount = 1000;

    List<Splatter> splatters = new List<Splatter>();
    

     
    void FixedUpdate()
    {
        Splat();
        Shade();
    }

    void Splat()
    {
        
        if (splatters.Count < splatterCount)
        {

            Splatter splatter = new Splatter();
            splatters.Add(splatter);
        }
        
    }

    void Shade()
    {
        foreach (var splatter in splatters)
        {
            if (splatter.collisionCounter > 1)
            {
                splatter.renderer.material.color = new Color(splatter.collisionCounter, splatter.collisionCounter, splatter.collisionCounter);
            }
           
        }
    }


    public class Splatter
    {
        GameObject @object = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        public Renderer renderer;
        public int collisionCounter;
        float x;
        float y;
        Vector2 windowBounds;

        public Splatter()
        {
            FindWindowLimits();
            renderer = @object.GetComponent<Renderer>();
            renderer.material = new Material(Shader.Find("Diffuse"));
            @object.transform.position = GaussianVector(x, y);
        }

        private void OnCollisionEnter(Collision collision)
        {
            collisionCounter += 25;
            
        }

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
