using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    Material material;

    float r, g, b, a;
    float x, y, z;

    void Start()
    {
        x = Random.Range(-180.0f, 180.0f);
        y = Random.Range(-180.0f, 180.0f);
        z = Random.Range(-180.0f, 180.0f);
        r = Random.Range(0.0f, 1.0f);
        g = Random.Range(0.0f, 1.0f);
        b = Random.Range(0.0f, 1.0f);
        a = Random.Range(0.0f, 1.0f);
        transform.localScale = Vector3.one * Random.Range(0.1f, 2.5f);
        material = Renderer.material;
        material.color = new Color(r, g, b, a);
        //InvokeRepeating("ChangeColor", .01f, 1.0f);
        StartCoroutine(ChangeColor(2));

    }

    private void OnMouseDown()
    {
        InvokeRepeating("ChangeColor", .01f, 1.0f);
    }

    void Update()
    {
        transform.Rotate(x * Time.deltaTime, y * Time.deltaTime, z * Time.deltaTime);
    }

    IEnumerator ChangeColor(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        r = Random.Range(0.0f, 1.0f);
        g = Random.Range(0.0f, 1.0f);
        b = Random.Range(0.0f, 1.0f);
        a = Random.Range(0.0f, 1.0f);
        material.color = new Color(r, g, b, a);
        StartCoroutine(ChangeColor(seconds));

    }
}
