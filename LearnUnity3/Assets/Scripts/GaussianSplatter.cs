using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaussianSplatter : MonoBehaviour
{
    public List<GameObject> splatters = new List<GameObject>();
    Vector3 location;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Splat();
    }

    void Splat()
    {
        
        if (splatters.Count < 5000)
        {
            GameObject @object = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            location = new Vector3(Random.Range(Random.Range(-30f, 30f), Random.Range(-30f, 30f)), Random.Range(Random.Range(-30f, 30f), Random.Range(-30f, 30f)), 0f);
            @object.transform.position = location;
            splatters.Add(@object);
        }
        //create a method that takes float args and returns the gaussian dist for the two

        //shade spheres based on how many other colliders are touching
    }

}
