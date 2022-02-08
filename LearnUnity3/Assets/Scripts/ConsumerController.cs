using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumerController : MonoBehaviour
{
    [SerializeField] int sphereCount = 1000;
    [SerializeField] GameObject sphere;

    List<GameObject> spheres = new List<GameObject>();
    Vector3 windowBounds;
    float x, y;

    void Start()
    {
        FindWindowLimits();
        StartCoroutine(AddSphere(1));
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

    IEnumerator AddSphere(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        if (spheres.Count < sphereCount)
        {
            GameObject newSphere = Instantiate(sphere);
            newSphere.transform.position = GaussianVector(x, y);
            spheres.Add(newSphere);
        }
        StartCoroutine(AddSphere(seconds));
    }
}
