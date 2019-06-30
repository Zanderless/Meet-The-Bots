/**
 * @file       : Screenshot.cs
 * @author     :
 * @description:
 * @note    
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshot : MonoBehaviour
{

    private void Update()
    {

        if (Application.isEditor)
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                UnityEngine.ScreenCapture.CaptureScreenshot("Screenshot_" + Random.Range(0, 100).ToString() + ".png");
            }
        }

    }

}
