using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaussianSplatter : MonoBehaviour
{
    [SerializeField] int splatterCount = 1000;

    List<GameObject> splatters = new List<GameObject>();
    float x;
    float y;
    Vector2 windowBounds; 

    private void Start()
    {
        FindWindowLimits();
        x = windowBounds.x;
        y = windowBounds.y;
        

    }

    void FixedUpdate()
    {
        Splat();
    }

    void Splat()
    {
        
        if (splatters.Count < splatterCount)
        {
            GameObject @object = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            Renderer renderer = @object.GetComponent<Renderer>();
            renderer.material = new Material(Shader.Find("Diffuse"));
            var location = GaussianVector(x, y);
            @object.transform.position = location;
            splatters.Add(@object);
        }
        //create a method that takes float args and returns gaussian distribution

        //shade spheres based on how many other colliders are touching
    }

    //void Shade()
    //{
    //    foreach (var splatter in splatters)
    //    {
           
    //    }
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
