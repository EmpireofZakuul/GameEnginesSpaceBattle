using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanCameraSwap : MonoBehaviour
{
    public float timeRemaining = 6;
    public bool timerIsRunning = false;
    public Camera panCamera;
    public Camera SidePanCamera;

    private void Start()
    {
       
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                panCamera.enabled = false;
                SidePanCamera.enabled = true;
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }
}
