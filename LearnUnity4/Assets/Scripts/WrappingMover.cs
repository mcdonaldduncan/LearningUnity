using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WrappingMover : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    class Mover
    {
        private Vector2 location, velocity;
        private Vector3 windowLimits;

        public Mover()
        {
            location = new Vector2(Random.Range());
        }

        void FindWindowLimits()
        {
            Camera.main.orthographic = true;
            windowLimits = new Vector3
            
        }

    }


}
