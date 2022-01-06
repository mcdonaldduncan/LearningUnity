using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendering : MonoBehaviour
{
    [SerializeField] GameObject centerSphere;
    [SerializeField] GameObject mouseSphere;
    [SerializeField] Camera cam;
    [SerializeField] int nodeCount;

    LineRenderer lineRenderer;
    Vector2 centerPos;
    List<GameObject> nodes = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = centerSphere.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Diffuse"));
        centerPos = (Vector2)centerSphere.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        nodeCount = nodes.Count;
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 followerPos = subtractVectors(mousePos, centerPos);
        mouseSphere.transform.position = followerPos;
        if (nodes.Count <= 0)
        {
            lineRenderer.SetPosition(0, centerPos);
            lineRenderer.SetPosition(1, followerPos);
        }
        else
        {
            lineRenderer.SetPosition(0, nodes[nodes.Count - 1].transform.position);
            lineRenderer.SetPosition(1, followerPos);
        }

        if (Input.GetMouseButtonUp(0))
        {
            GameObject node = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            node.transform.position = mousePos;
            nodes.Add(node);
            LineRenderer line = Instantiate(lineRenderer);
            line = node.AddComponent<LineRenderer>();
            line.material = new Material(Shader.Find("Diffuse"));
            
            if (nodes.Count > 2)
            {
                line.SetPosition(0, nodes[nodes.Count - 2].transform.position);
                line.SetPosition(1, node.transform.position);
                Debug.Log("more than 2");
            }
            else if (nodes.Count > 1)
            {
                line.SetPosition(0, nodes[0].transform.position);
                line.SetPosition(1, node.transform.position);
                Debug.Log("more than 1");
            }
            else
            {
                line.SetPosition(0, centerPos);
                line.SetPosition(1, node.transform.position);
                Debug.Log("more than 0");
            }
        }
    }

    Vector2 subtractVectors(Vector2 vector1, Vector2 vector2)
    {
        Vector2 newVector = vector1 - vector2;
        return newVector;
    }
}
