using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Nature of Code Unity

public class MagnitudeCalc : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] GameObject centerSphere;
    [SerializeField] GameObject cursorSphere;

    // Create variables for rendering the line between two vectors
    private LineRenderer lineRender;
    private LineRenderer magLineRender;

    // Start is called before the first frame update
    void Start()
    {
        // Create two new line renderers. We must create new GameObjects since one
        // object cannot accept more than one of this component
        GameObject newA = new GameObject();
        GameObject newB = new GameObject();
        lineRender = newA.AddComponent<LineRenderer>();
        magLineRender = newB.AddComponent<LineRenderer>();
        //We need to create a new material for WebGL
        lineRender.material = new Material(Shader.Find("Diffuse"));
        //We need to create a new material for WebGL
        magLineRender.material = new Material(Shader.Find("Diffuse"));
    }

    // Update is called once per frame
    void Update()
    {
        // Track the Vector2 of the mouse's position and the center sphere's position
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 centerPos = centerSphere.transform.position;
        // Move the cursor sphere directly to the mouse
        cursorSphere.transform.position = mousePos;

        // Calculate the magnitude(the distance between the two spheres)
        Vector2 differenceVector = subtractVectors(mousePos, centerPos);
        float magnitude = magnitudeOf(differenceVector);

        // Render the line between the spheres directly 
        lineRender.SetPosition(0, centerPos);
        lineRender.SetPosition(1, mousePos);

        // Render a bar in the top left of the screen with the same length as the vector
        Vector2 cameraTopLeft = cam.ScreenToWorldPoint(new Vector2(0, Screen.height));
        magLineRender.SetPosition(0, cameraTopLeft);
        // Use of Unity's built in Vector2 operators:
        magLineRender.SetPosition(1, cameraTopLeft + magnitude * Vector2.right);
    }

    // This method finds the length of a vector using pythagoras theorem
    // magnitudeOf(vec) will yield the same output as Unity's built in property vect.magnitude
    float magnitudeOf(Vector2 vector)
    {
        return Mathf.Sqrt(vector.x * vector.x + vector.y * vector.y);
    }

    // This method calculates A - B component wise
    // subtractVectors(vecA, vecB) will yield the same output as Unity's built in operator: vecA - vecB
    Vector2 subtractVectors(Vector2 vectorA, Vector2 vectorB)
    {
        float newX = vectorA.x - vectorB.x;
        float newY = vectorA.y - vectorB.y;
        return new Vector2(newX, newY);
    }
}
