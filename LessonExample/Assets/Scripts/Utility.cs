using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility
{
    public static Vector3 FindWindowLimits()
    {
        Camera.main.transform.position = new Vector3(0, 0, -10);
        Vector3 windowLimits = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        return windowLimits;
    }
}
