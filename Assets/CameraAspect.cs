using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAspect : MonoBehaviour
{
    void Start()
    {
        Camera cam = GetComponent<Camera>();

        float screenAspect = (float)Screen.width / Screen.height;
        float targetAspect = 1.0f; // 1:1

        if (screenAspect > targetAspect)
        {
            float scale = targetAspect / screenAspect;
            cam.rect = new Rect((1f - scale) / 2f, 0f, scale, 1f);
        }
        else
        {
            float scale = screenAspect / targetAspect;
            cam.rect = new Rect(0f, (1f - scale) / 2f, 1f, scale);
        }
    }
}