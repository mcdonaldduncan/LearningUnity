using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CubeMover : MonoBehaviour
{
    [SerializeField]
    private float speed = 1;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, vertical);

        transform.position += movement * Time.deltaTime * speed;
        // Multiply by Time.deltaTime to tie movement to time not frame. Checks the time since last call and multiplies by value to keep timing consistent.

    }

    private void OnCollisionEnter(Collision collision)
    {
        SceneManager.LoadScene(0);
    }
}
