using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderScript : MonoBehaviour
{
    [SerializeField] Renderer r;
    int collisionCounter;

    private void OnCollisionEnter(Collision collision)
    {
        collisionCounter++;
        //Debug.Log("collision detected");
    }

    void Update()
    {
        Shade();
    }

    void Shade()
    {
        if (collisionCounter == 0)
        {
            r.material.color = new Color32(42, 72, 88, 1);
        }
        if (collisionCounter >= 1)
        {
            r.material.color = new Color32(37, 85, 102, 1);
        }
        if (collisionCounter >= 2)
        {
            r.material.color = new Color32(28, 99, 115, 1);
        }
        if (collisionCounter >= 3)
        {
            r.material.color = new Color32(11, 113, 126, 1);
        }
        if (collisionCounter >= 4)
        {
            r.material.color = new Color32(0, 127, 134, 1);
        }
        if (collisionCounter >= 5)
        {
            r.material.color = new Color32(0, 141, 140, 1);
        }
        if (collisionCounter >= 6)
        {
            r.material.color = new Color32(0, 156, 143, 1);
        }
        if (collisionCounter >= 7)
        {
            r.material.color = new Color32(35, 170, 143, 1);
        }
        if (collisionCounter >= 8)
        {
            r.material.color = new Color32(63, 183, 141, 1);
        }
        if (collisionCounter >= 9)
        {
            r.material.color = new Color32(91, 196, 137, 1);
        }
        if (collisionCounter >= 10)
        {
            r.material.color = new Color32(119, 209, 131, 1);
        }
    }
}
