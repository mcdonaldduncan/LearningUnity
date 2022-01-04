using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaussianSplatter : MonoBehaviour
{
    [SerializeField]public int splatterCount = 1000;

    List<GameObject> splatters = new List<GameObject>();
   
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
            Collider collider = @object.GetComponent<Collider>();
            var location = GaussianVector(-30f, 30f);
            @object.transform.position = location;
            splatters.Add(@object);
        }
        //create a method that takes float args and returns gaussian distribution

        //shade spheres based on how many other colliders are touching
    }

    //void Shade()
    //{
    //    foreach (var i in splatters)
    //    {
           
    //    }
    //}

    Vector3 GaussianVector(float negativeBound, float positiveBound)
    {
        var gaussianVector = new Vector3(Random.Range(Random.Range(negativeBound, positiveBound), Random.Range(negativeBound, positiveBound)), Random.Range(Random.Range(negativeBound, positiveBound), Random.Range(negativeBound, positiveBound)), 0f);
        return gaussianVector;
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
