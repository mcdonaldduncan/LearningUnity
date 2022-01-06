using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderScript : MonoBehaviour
{
    [SerializeField] int collisionCounter;
    //[SerializeField] Material material;
    [SerializeField] Renderer r;
    int R;
    int G;
    int B;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        r.material.color = new Color(42, 72, 88);

    }

    //private void OnCollisionStay(Collision collision)
    //{
    //    collisionCounter++;
    //    Debug.Log("collision detected");
    //}

    private void OnCollisionEnter(Collision collision)
    {
        collisionCounter++;
        Debug.Log("collision detected");
        
    }

    // Update is called once per frame
    void Update()
    {
        Shade();


    }

    void Shade()
    {
        //r = GetComponent<Renderer>();
        //material = GetComponent<Material>();
        

        if (collisionCounter > 4)
        {
            r.material.color = new Color(0, 127, 134);
        }
        else if (collisionCounter > 3)
        {
            r.material.color = new Color(11, 113, 126);
        }
        else if (collisionCounter > 2)
        {
            r.material.color = new Color(28, 99, 115);
        }
        else if (collisionCounter > 1)
        {
            r.material.color = new Color(37, 85, 102);
        }
        else
        {
            r.material.color = new Color(42, 72, 88);
        }


        //if (collisionCounter > 1)
        //{
        //    r.material.color = new Color(37, 85, 102);
        //    if (collisionCounter > 2)
        //    {
        //        r.material.color = new Color(28, 99, 115);
        //        if (collisionCounter > 3)
        //        {
        //            r.material.color = new Color(11, 113, 126);
        //            if (collisionCounter > 4)
        //            {
        //                r.material.color = new Color(0, 127, 134);
        //            }
        //        }
                
        //    }
            
        //}
        


    }
}
