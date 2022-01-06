using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadedColliders : MonoBehaviour
{
    [SerializeField] int splatterCount = 5000;

    List<GameObject> splatters = new List<GameObject>();
    GameObject prefab;
    Vector3 windowBounds;
    float x;
    float y;

    void Start()
    {
        prefab = Resources.Load("Sphere") as GameObject;
        FindWindowLimits();

        //for (int i = 0; i < splatterCount; i++)
        //{
        //    GameObject go = Instantiate(prefab) as GameObject;
        //    go.transform.position = GaussianVector(x, y);
        //}
    }

    
    void Update()
    {

        Splat();
        
    }

    void Splat()
    {

        if (splatters.Count < splatterCount)
        {
            GameObject splatter = Instantiate(prefab) as GameObject;
            splatter.transform.position = GaussianVector(x, y);
            splatters.Add(splatter);
        }
        
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
