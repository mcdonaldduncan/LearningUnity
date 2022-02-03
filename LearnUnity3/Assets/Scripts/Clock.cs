using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Clock : MonoBehaviour
{
    [SerializeField] TMP_Text clockText;
    [SerializeField] RectTransform rectTransform;
    Vector2 windowLimits;
    

    // Start is called before the first frame update
    void Start()
    {
        FindWindowLimits();
        rectTransform.position = new Vector3(-windowLimits.x + 3.0f, -windowLimits.y + 2.0f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        clockText.text = DateTime.Now.ToString();
    }

    void FindWindowLimits()
    {
        Camera.main.orthographic = true;
        windowLimits = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        
    }
}
