using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] int cubeCount = 100;
    [SerializeField] GameObject cube;
    List<GameObject> cubes = new List<GameObject>();
    Vector3 windowBounds;
    float x, y;

    void Start()
    {
        FindWindowLimits();
        StartCoroutine(AddCube(2));
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

    IEnumerator AddCube(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        if (cubes.Count < cubeCount)
        {
            GameObject newCube = Instantiate(cube);
            newCube.transform.position = GaussianVector(x, y);
            cubes.Add(newCube);
        }
        StartCoroutine(AddCube(seconds));
    }
}
